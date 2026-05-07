using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData data;
    private Transform[] path;
    private int waypointIndex = 0;
    private float currentHealth;

    public void Initialize(EnemyData newData, Transform[] waypoints)
    {
        data = newData;
        path = waypoints;
        waypointIndex = 0;

        currentHealth = data != null ? data.health : 10f;

        if (data != null && data.visualSprite != null)
            GetComponent<SpriteRenderer>().sprite = data.visualSprite;

        if (path != null && path.Length > 0)
            transform.position = path[0].position;
    }

    void Update()
    {
        if (path == null || waypointIndex >= path.Length) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            path[waypointIndex].position,
            (data != null ? data.speed : 2f) * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, path[waypointIndex].position) < 0.1f)
            waypointIndex++;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}