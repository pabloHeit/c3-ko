using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField]public Sprite attack1;
   [SerializeField]public Sprite attack2;
   private Image image;

    // Start is called before the first frame update
    void Start()
    {   
        Image image = GetComponent<Image>();
        image.sprite =attack1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
