using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public Button startButton;
    public GameObject tutorialLabel;
    public GameObject youLoseLabel;
    public bool gameStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
        tutorialLabel.SetActive(true);
        youLoseLabel.SetActive(false);
        player = GameObject.FindWithTag("Player");

        if (gameStart && player == null)
        {
            Debug.Log("Cannot Find Player");
            EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && player == null)
        {
            EndGame();
        }
    }
    void OnStartClicked()
    {
        tutorialLabel.SetActive(false);
        gameStart = true;
    }

    void EndGame()
    {
        youLoseLabel.SetActive(true);
        gameStart = false;
    }
}
