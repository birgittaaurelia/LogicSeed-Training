using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Movement movementCharacter;
    public GameObject player;
    public Button startButton;
    public GameObject tutorialLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
        movementCharacter = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnStartClicked()
    {
        tutorialLabel.SetActive(false);
        movementCharacter.canMove = true;
    }
}
