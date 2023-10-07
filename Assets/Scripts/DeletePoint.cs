using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoint : MonoBehaviour
{
    private Note note;
    [SerializeField] Inputs inputsObject;

    private void Awake() {
        note = GetComponent<Note>();
        //inputsObject = gameObject.GetComponent<Inputs>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.GetComponent<Note>())
        {
            inputsObject.OnLosePoints(10);
            Destroy(other.gameObject);
        }
    }
}