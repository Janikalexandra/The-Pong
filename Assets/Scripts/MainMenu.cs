using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            Debug.Log("Quit");
        #endif     
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
