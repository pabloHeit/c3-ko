using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHits : MonoBehaviour
{
    [SerializeField]public Sprite attack1;
   [SerializeField]public Sprite attack2;
   [SerializeField]public Sprite attack3;
   [SerializeField]public Sprite attack4;
   [SerializeField]public Sprite empty;
//
    
    

    public void ChangeSprite()
    {
        // Obtener el componente SpriteRenderer del objeto
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Cambiar el sprite
            switch(Random.Range(1,5))
            {
                case 1:spriteRenderer.sprite = attack1;
                break;
                case 2:spriteRenderer.sprite = attack2;
                break;
                case 3:spriteRenderer.sprite = attack3;
                break;
                case 4:spriteRenderer.sprite = attack4;
                break;
            }
                
           
                
            
            
            
            Invoke("None", 5f);
    }

    private void None()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = empty;
    }
}
