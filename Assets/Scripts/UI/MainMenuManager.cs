using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu, CreditsMenu;  

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void CloseAll()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        CloseAll();
        CreditsMenu.SetActive(true);
    }
    public void OpenCredits()
    {
        CloseAll();
        CreditsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //fade in transition for main menu buttons
}

