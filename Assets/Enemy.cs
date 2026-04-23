using UnityEngine;
using UnityEngine.UI; 

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public Slider healthBar; 
    private float currentHealth;
    
    private Transform[] path;
    private int waypointIndex;

    public void Initialize(EnemyData newData, Transform[] waypoints)
    {
        data = newData;
        path = waypoints;
        currentHealth = data.health; 
        
        // Налаштування візуалу
        GetComponent<SpriteRenderer>().sprite = data.visualSprite;
        
        // Налаштування HP
        if (healthBar != null)
        {
            healthBar.maxValue = data.health;
            healthBar.value = data.health;
        }

        // Ставимо ворога в саму першу точку відразу при появі
        if (path != null && path.Length > 0)
        {
            transform.position = path[0].position;
            waypointIndex = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (healthBar != null) healthBar.value = currentHealth;

        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        // Перевірка чи є куди йти
        if (path == null || waypointIndex >= path.Length) return;

        // Рух до поточної точки
        transform.position = Vector2.MoveTowards(
            transform.position, 
            path[waypointIndex].position, 
            data.speed * Time.deltaTime
        );

        // Якщо підійшли впритул до точки — перемикаємось на наступну
        if (Vector2.Distance(transform.position, path[waypointIndex].position) < 0.1f) 
        {
            waypointIndex++;
        }

        // Якщо дійшли до кінця шляху — видаляємо ворога 
        if (waypointIndex >= path.Length)
        {
            Die(); 
        }
    }
}