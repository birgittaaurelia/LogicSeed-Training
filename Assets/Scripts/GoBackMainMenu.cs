using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackMainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
