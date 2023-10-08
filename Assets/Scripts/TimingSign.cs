using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingSign : MonoBehaviour
{
    public Sprite good;
    public Sprite perfect;
    public Sprite miss;

    public void ChangeSprite(Sprite newSprite)
    {
        // Obtener el componente SpriteRenderer del objeto
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Cambiar el sprite
            spriteRenderer.sprite = newSprite;
    }
    
}
