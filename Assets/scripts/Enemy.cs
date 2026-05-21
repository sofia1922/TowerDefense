using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData data;
    private Transform[] path;
    private int waypointIndex = 0;

<<<<<<< HEAD
    private float currentHealth;

    [Header("Health Bar")]
    public Transform hpBarFill;

    [Header("Freeze")]
    private float currentSpeed;
    private float originalSpeed;
    private float slowTimer = 0f;

    private AudioSource audioSource;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        audioSource = GetComponent<AudioSource>();
    }

    public void Initialize(EnemyData newData, Transform[] waypoints)
    {
        data = newData;

        path = waypoints;

        waypointIndex = 0;

        currentHealth = data.health;

        originalSpeed = data.speed;
        currentSpeed = originalSpeed;

        if (data != null && data.visualSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite =
                data.visualSprite;
        }

=======
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
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
        if (path != null && path.Length > 0)
        {
            transform.position = path[0].position;
        }
<<<<<<< HEAD

        UpdateHealthBar();
=======
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
    }

    void Update()
    {
<<<<<<< HEAD
        if (path == null || waypointIndex >= path.Length)
            return;

        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0)
            {
                currentSpeed = originalSpeed;
            }
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            path[waypointIndex].position,
            currentSpeed * Time.deltaTime
        );

        if (Vector2.Distance(
            transform.position,
            path[waypointIndex].position
        ) < 0.1f)
=======
        if (path == null || waypointIndex >= path.Length) return;

        // Рух строго за списком точок
        transform.position = Vector2.MoveTowards(
            transform.position, 
            path[waypointIndex].position, 
            (data != null ? data.speed : 2f) * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, path[waypointIndex].position) < 0.1f)
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
        {
            waypointIndex++;
        }
    }
<<<<<<< HEAD

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(
            currentHealth,
            0,
            data.health
        );

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplySlow(float slowPercent, float duration)
    {
        if (data != null && data.immuneToFreeze)
        {
            return;
        }

        currentSpeed =
            originalSpeed * (1f - slowPercent);

        slowTimer = duration;
    }

    void Die()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        if (gm != null && data != null)
        {
            gm.AddGold(data.rewardGold);

            Debug.Log(
                "Enemy killed. Added gold: "
                + data.rewardGold
            );
        }

        if (data != null && data.deathSound != null)
        {
            AudioSource.PlayClipAtPoint(
                data.deathSound,
                transform.position
            );
        }

        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (hpBarFill == null || data == null)
            return;

        float hpPercent =
            currentHealth / data.health;

        Vector3 scale =
            hpBarFill.localScale;

        scale.x = 0.58f * hpPercent;

        hpBarFill.localScale = scale;

        Vector3 pos =
            hpBarFill.localPosition;

        pos.x = -(0.58f - scale.x) / 2f;

        hpBarFill.localPosition = pos;
    }
=======
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
}