using UnityEngine.UI; // ADD THIS: For the Image component
using Yarn.Unity;     // ADD THIS: For the [YarnCommand] attribute
using UnityEngine;
using System.Collections;
public class FadeAnimation2 : MonoBehaviour
{
    private Image characterImage;
    public static int BugCounter = 0;
    void Awake() {
        characterImage = GetComponent<Image>();
    }
    
    // This makes the command available in your Yarn Script
    [YarnCommand("fade")]
    public void FadeCharacter(string direction) {
        float targetAlpha;

        if (direction == "in") {
            targetAlpha = 1f;
        } else {
            
            if(GetComponent<Button>() != null){
                targetAlpha=0f;
                BugCounter++;
            }
            else{
                targetAlpha=0.3f;
            }
            // Optional: Disable the button so it can't be clicked while invisible
            if (GetComponent<Button>() != null) {
                GetComponent<Button>().interactable = false;
            }
        }

        StartCoroutine(DoFade(targetAlpha));
    }

    IEnumerator DoFade(float targetAlpha) {
        float duration = 1.0f; // Seconds the fade lasts
        float startAlpha = characterImage.color.a;
        float timer = 0;

        while (timer < duration) {
            timer += Time.deltaTime;
            Color c = characterImage.color;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, timer / duration);
            characterImage.color = c;
            yield return null;
        }
    }
}
