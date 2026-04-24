using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData data;
    private Transform[] path;
    private int waypointIndex = 0;

    private void OnDrawGizmos()
{
    if (path == null || waypointIndex >= path.Length) return;
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, path[waypointIndex].position);
}

    public void Initialize(EnemyData newData, Transform[] waypoints)
    {
        this.data = newData;
        this.path = waypoints;
        
        // Встановлюємо спрайт з даних
        if (data != null && data.visualSprite != null)
            GetComponent<SpriteRenderer>().sprite = data.visualSprite;

        // ВАЖЛИВО: Примусово ставимо ворога в першу точку
        if (path != null && path.Length > 0)
        {
            transform.position = path[0].position;
        }
    }

    void Update()
    {
        if (path == null || waypointIndex >= path.Length) return;

        // Рух строго за списком точок
        transform.position = Vector2.MoveTowards(
            transform.position, 
            path[waypointIndex].position, 
            (data != null ? data.speed : 2f) * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, path[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
        }
    }
}