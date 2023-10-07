using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    [Header("Inputs")]
    private KeyCode key = KeyCode.Space;

    [SerializeField] private bool keypressed;
    [SerializeField] public int points;

    private void Update(){
        if(Input.GetKey(key))
        {
            keypressed = true;
        }
        else
        {
            keypressed=false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {

        Note note = other.gameObject.GetComponent<Note>();


        if (keypressed==true)
        {
            note.OnPressed(transform);
            points += 50;
        }   
    }
}
