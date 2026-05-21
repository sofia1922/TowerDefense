using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData data;
    private Transform[] path;
    private int waypointIndex = 0;

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

        if (path != null && path.Length > 0)
        {
            transform.position = path[0].position;
        }

        UpdateHealthBar();
    }

    void Update()
    {
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
        {
            waypointIndex++;
        }
    }

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
}