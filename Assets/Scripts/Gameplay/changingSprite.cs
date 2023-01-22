using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingSprite : MonoBehaviour
{
    public SpriteRenderer levierSprite;
    public Sprite newSprite;
    public void changerSprite ()
    {
        levierSprite.sprite = newSprite;
    }
}
