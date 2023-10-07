using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoint : MonoBehaviour
{
     private Note note;

    private void Awake() {
        note = GetComponent<Note>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.GetComponent<Note>())
        {
            Destroy(other.gameObject);
        }
    }
}