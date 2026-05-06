using UnityEngine;
using TMPro;

public class ChangePoints : MonoBehaviour
{
    public int currPoint = 0;
    public TextMeshProUGUI uiText;
    void Start()
    {
        uiText.text = "Score: " + currPoint;
    }

    public void addPoints(int points)
    {
        currPoint += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        uiText.text = "Score: " + currPoint;
    }
    
    public void SaveMaxPoints()
    {
        int highScore = PlayerPrefs.GetInt("MaxPoints", 0);

        if (currPoint > highScore)
        {
            PlayerPrefs.SetInt("MaxPoints", currPoint);
            PlayerPrefs.Save();
        }
    }
}
