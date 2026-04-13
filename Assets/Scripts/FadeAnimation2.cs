using UnityEngine.UI; // ADD THIS: For the Image component
using Yarn.Unity;     // ADD THIS: For the [YarnCommand] attribute
using UnityEngine;
using System.Collections;
public class FadeAnimation2 : MonoBehaviour
{
    private Image characterImage;

    void Awake() {
        characterImage = GetComponent<Image>();
    }

    // This makes the command available in your Yarn Script
    [YarnCommand("fade")]
    public void FadeCharacter(string direction) {
        float targetAlpha = (direction == "in") ? 1f : 0.3f;
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
