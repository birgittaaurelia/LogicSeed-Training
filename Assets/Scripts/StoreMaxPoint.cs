using UnityEngine;
using TMPro;

public class StoreMaxPoint : MonoBehaviour
{
    public TextMeshProUGUI highScoreDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int savedMax = PlayerPrefs.GetInt("MaxPoints", 0);
        highScoreDisplay.text = "Best Score: " + savedMax;
    }
}
