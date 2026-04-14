using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Image targetImage;   
    [SerializeField] private Sprite newSprite;    
    
    public Sprite newBackground;
    private Image backgroundImage;
    private bool hasChanged = false;

    public static int SwitchesOnCount; // The global counter
   public static GameObject globalNavButton;
    [SerializeField] private GameObject navButtonAssignment; // Use this for the Inspector

void Awake() 
{
    SwitchesOnCount = 0; // Reset counter
    // Link the inspector slot to our static variable so everyone can see it
    if (navButtonAssignment != null) {
        globalNavButton = navButtonAssignment;
        
    }
}
    void Update()
    {
        if (!hasChanged && FadeAnimation2.BugCounter >= 5) 
        {
            ChangeBackground();
            hasChanged = true; 

            // 3. Immediately switch the scene
            Debug.Log("5 Bugs cleared! Moving to the next scene.");
            FindAnyObjectByType<Yarn.Unity.DialogueRunner>().StartDialogue("DuringTreeRoom");
            //SceneManager.LoadScene("Scene4"); // Change "Scene4" to whatever your next scene is named
        }

        if (SwitchesOnCount >= 4)
    {
        Debug.Log("All tasks complete! Transitioning...");
        
        // Reset the counter so it doesn't try to load the scene 60 times a second
        SwitchesOnCount = 0; 
        
        // Option A: Instant jump
        SceneManager.LoadScene("AfterMiniGame1");
    }
    }
    public void ChangeSprite()
    {
        if (targetImage != null && newSprite != null)
    {
        targetImage.sprite = newSprite;
        SwitchesOnCount++;
        Debug.Log("Switches flipped: " + SwitchesOnCount);

        // Use the GLOBAL reference now
        if (SwitchesOnCount >= 4 && globalNavButton != null)
        {
            globalNavButton.SetActive(true);
            Debug.Log("Global Nav Button Activated!");
        }
        
        if(GetComponent<Button>() != null) GetComponent<Button>().interactable = false;
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