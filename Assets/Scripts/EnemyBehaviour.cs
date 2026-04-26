using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemySO data;
    public Transform player;
    private Rigidbody2D rbEnemy;
    public int health;
    public float speed;
    public int damage;
    public float lastAttack;
    public float attackCooldown;

    public void Initialize (EnemySO enemySO)
    {
        data = enemySO;
        health = data.health;
        speed = data.speed;
        damage = data.damage;
        attackCooldown = data.attackCooldown;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null || data == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= 50f)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rbEnemy.linearVelocity = direction * data.speed;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttack + attackCooldown)
            {
                DealDamage(collision.gameObject);
                lastAttack = Time.time;
            }
        }
    }

    void DealDamage(GameObject playerObj)
    {
        Debug.Log(data.enemyName + "Hit player");

        PlayerHealth hp = playerObj.GetComponent<PlayerHealth>();
        if (hp != null)
        {
            hp.TakeDamage(data.damage);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
