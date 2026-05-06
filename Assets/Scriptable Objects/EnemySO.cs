using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Create Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public GameObject prefab;
    public int health;
    public float speed;
    public int damage;
    public int points;
    public float attackCooldown;
}
