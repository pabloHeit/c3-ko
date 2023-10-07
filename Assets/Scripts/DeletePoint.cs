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
        Note note = other.gameObject.GetComponent<Note>();
        note.Destroy();
    }
}