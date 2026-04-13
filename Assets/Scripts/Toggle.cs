using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Image targetImage;   
    [SerializeField] private Sprite newSprite;    

    public void ChangeSprite()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
    }
}