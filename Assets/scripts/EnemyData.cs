using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "TowerDefense/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float health;
    public float speed;
    public int rewardGold;
    public int attackCost;
    public Sprite visualSprite;

    public AudioClip deathSound;
}