using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Image targetImage;   
    [SerializeField] private Sprite newSprite;    
    
    public Sprite newBackground;
    private Image backgroundImage;
    private bool hasChanged = false;
    public void FinishedAnimation()
    {
        //idea is if the fourth of fifth switch was pressed from off to on then that would trigger the navbutton to navigate you back
        //to the control room.
        // also idea for yarnspinner is that you have a boolean value that let say minigame_dialogue = false initially then you set it to be true once 
        //space women finished talking and then you click the nav buton to the minigame. 
    }
    void Update()
    {
        if (!hasChanged && FadeAnimation2.BugCounter >= 5) 
        {
            ChangeBackground();
        }
    }
    public void ChangeSprite()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
    }
    void ChangeBackground() {
      if (backgroundImage == null) {
            backgroundImage = GetComponent<Image>();
        }

        if (backgroundImage != null && newBackground != null)
        {
            backgroundImage.sprite = newBackground;
            hasChanged = true; // Stop it from running every frame once successful
            Debug.Log("Tree Healed!");
        }
        else 
        {
            // This will tell us exactly what is still missing in the Console
            if (backgroundImage == null) Debug.LogError("Still can't find the Image component on this object!");
            if (newBackground == null) Debug.LogError("New Background slot is empty!");
        }
    }
    
}