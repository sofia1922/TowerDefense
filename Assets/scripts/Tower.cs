using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Settings")]
    public float range = 9f;
    public int damage = 50;
    public float fireRate = 5f;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Enemy target = FindClosestEnemy();

        if (target != null && fireCooldown <= 0f)
        {
            Shoot(target);
            fireCooldown = 1f / fireRate;
        }
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < range && distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    void Shoot(Enemy target)
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bulletObject = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );

            Bullet bullet = bulletObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.SetTarget(target, damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}