using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public Slider healthBar;
    public ChangePoints scoreScript;

    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        scoreScript = GetComponent<ChangePoints>();
    }
    void Update()
    {
        healthBar.value = health;
    }
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
        scoreScript.SaveMaxPoints();
        Destroy(gameObject);
    }
}
