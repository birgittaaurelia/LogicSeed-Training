using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player HP Decreased");

        if (health <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}
