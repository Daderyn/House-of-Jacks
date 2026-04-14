using UnityEngine;
using UnityEngine.UI; // ADD THIS: For the Image component
using Yarn.Unity;     // ADD THIS: For the [YarnCommand] attribute

public class YarnCommands : MonoBehaviour
{
    private Image characterImage;
    [SerializeField] public Sprite neutral;
    [SerializeField] public Sprite happy;
    [SerializeField] public Sprite angry;
    [SerializeField] public Sprite sad;
    [SerializeField] public Sprite surprised;
    [SerializeField] public Sprite shocked;

    void Awake() {
        characterImage = GetComponent<Image>();
    }

    [YarnCommand("SetSprite")]
    public void SetSprite(string emotion)
    {
        Sprite newSprite; 
        switch(emotion){
            case "neutral":
                newSprite = neutral;
                break;
            case "happy":
                newSprite = happy;
                break;
            case "sad":
                newSprite = sad;
                break;
            case "surprised":
                newSprite = surprised;
                break;
            case "shocked":
                newSprite = shocked;
                break;
            case "angry":
                newSprite = angry;
                break;
            default:
                newSprite = neutral;
                break;
        }

        characterImage.sprite = newSprite;

    }
}
