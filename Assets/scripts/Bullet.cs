using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private Enemy target;
    private float damage;

    public void SetTarget(Enemy enemy, float bulletDamage)
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

        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}