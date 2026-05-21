using UnityEngine;

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
}