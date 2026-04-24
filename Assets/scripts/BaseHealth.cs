using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider damageSlider; 

    void Start()
    {
        currentHealth = maxHealth;
        if (damageSlider != null)
        {
            damageSlider.maxValue = maxHealth;
            damageSlider.value = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10); 
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (damageSlider != null)
        {
            damageSlider.value = maxHealth - currentHealth;
        }

        if (currentHealth <= 0)
        {
            GameOver(); // Тут виникала помилка, бо метод нижче був відсутній
        }
    }

    // Цей блок має бути ТУТ (всередині класу)
    void GameOver()
    {
        Debug.Log("БАЗУ ЗРУЙНОВАНО!");
        // Time.timeScale = 0; // Ми це закоментували, щоб гра не висла
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
} 