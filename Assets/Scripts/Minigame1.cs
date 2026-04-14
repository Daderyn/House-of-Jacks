using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using System.Collections; // Needed for Coroutines

public class Minigame1 : MonoBehaviour
{
    public GameObject playButton;

    // Fixed: Added isGlobal to prevent the "target not specified" error
    [YarnCommand("show_button_tree_room")]
    public void ShowButtonForTreeRoom()
    {
        StartCoroutine(WaitAndShowTreeRoom(1.0f));
    }

    IEnumerator WaitAndShowTreeRoom(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playButton != null)
        {
            playButton.SetActive(true);
            SceneManager.LoadScene("TreeRoom"); // Hard-coded for Scene 3
        }
    }

    [YarnCommand("show_button")]
    public void ShowTheButton()
    {
        // Start the delay timer
        StartCoroutine(WaitAndShow(1.0f)); // 
    }

    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void OnPlayButtonClicked()
    {
        switchScene("Scene2"); // Put your next scene name here
    }
    
   
    public void ReturnToControlRoom()
    {
        SceneManager.LoadScene("ControlRoomScene"); 
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

    
    
}