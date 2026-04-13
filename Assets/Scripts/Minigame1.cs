using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using System.Collections; // Needed for Coroutines

public class Minigame1 : MonoBehaviour
{
    public GameObject playButton;

    // Fixed: Added isGlobal to prevent the "target not specified" error
    [YarnCommand("show_button")]
    public void ShowTheButton()
    {
        // Start the delay timer
        StartCoroutine(WaitAndShow(1.0f)); // 1.5 second delay
    }

    
    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void OnPlayButtonClicked()
    {
        switchScene("Scene2"); // Put your next scene name here
    }


    IEnumerator WaitAndShow(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playButton != null)
        {
            playButton.SetActive(true);
            OnPlayButtonClicked();
            Debug.Log("Button popped up after delay!");
        }
    }

    // This is the function the button needs to call
    
}