using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    [Header("AOE")]
    public bool isAOE = false;
    public float aoeRadius = 1.5f;

    [Header("Freeze")]
    public bool isFreezer = false;
    public float slowPercent = 0.5f;
    public float slowDuration = 2f;

    private Enemy target;
    private int damage;

    public void SetTarget(Enemy enemy, int bulletDamage)
    {
        target = enemy;
        damage = bulletDamage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.transform.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(
            transform.position,
            target.transform.position
        ) < 0.1f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        if (isAOE)
        {
            Enemy[] enemies =
                FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                float distance = Vector2.Distance(
                    transform.position,
                    enemy.transform.position
                );

                if (distance <= aoeRadius)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        else
        {
            target.TakeDamage(damage);

            if (isFreezer)
            {
                target.ApplySlow(
                    slowPercent,
                    slowDuration
                );
            }
        }

        Destroy(gameObject);
    }
}