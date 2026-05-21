using UnityEngine;

<<<<<<< HEAD
[CreateAssetMenu(
    fileName = "NewEnemyData",
    menuName = "TowerDefense/EnemyData"
)]
public class EnemyData : ScriptableObject
{
    [Header("Basic")]
    public string enemyName;

    public float health;

    public float speed;

    public int rewardGold;

    public int attackCost;

    public Sprite visualSprite;

    [Header("Audio")]
    public AudioClip deathSound;

    [Header("Special")]
    public bool immuneToFreeze = false;
=======
[CreateAssetMenu(fileName = "NewEnemyData", menuName = "TowerDefense/EnemyData")]
public class EnemyData : ScriptableObject 
{
    public string enemyName;
    public float health;
    public float speed;
    public int rewardGold;
    public int attackCost; 
    public Sprite visualSprite;
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
}