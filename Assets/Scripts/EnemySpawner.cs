using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public Transform[] spawnPos;
    public EnemySO[] enemySO;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (gameManager != null && gameManager.gameStart)
                spawnEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Wait2Second()
    {
        yield return new WaitForSeconds(2f);
    }

    public void spawnEnemy()
    {
        for (int i=0; i<enemySO.Length; i++)
        {
            GameObject obj = Instantiate(enemySO[i].prefab, spawnPos[i].position, Quaternion.identity);

            EnemyBehaviour enemy = obj.GetComponent<EnemyBehaviour>();
            
            if (enemy != null)
            {
                enemy.Initialize(enemySO[i]);
            }
        }
    }
}
