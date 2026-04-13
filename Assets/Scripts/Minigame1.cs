using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Minigame1 : MonoBehaviour
{
    
    // Update is called once per frame
    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
