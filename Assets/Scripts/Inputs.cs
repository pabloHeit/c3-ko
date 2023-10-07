using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inputs : MonoBehaviour
{
    [Header("Inputs")]
    private KeyCode key = KeyCode.Space;

    [SerializeField]private KeyCode blue = KeyCode.Q;
    [SerializeField]private KeyCode violet = KeyCode.W;
    [SerializeField]private KeyCode red = KeyCode.E;
    [SerializeField]private KeyCode green = KeyCode.R;

    [SerializeField] private int _points;

    [SerializeField] TextMeshProUGUI pointsText;


    Colors keyPressed;

    private void Update(){
        if(Input.GetKey(blue))
        {
           keyPressed=Colors.Blue;
           return;
        }
        if(Input.GetKey(violet))
        {
           keyPressed=Colors.Violet;
           return;
        }
        if(Input.GetKey(red))
        {
            keyPressed=Colors.Red;
            return;
        }   
        if(Input.GetKey(green))
        {
            keyPressed=Colors.Green;
            return;
        }
        keyPressed=Colors.none;
        
    }
    private void OnTriggerStay2D(Collider2D other) {

        Note note = other.gameObject.GetComponent<Note>();

        if(note.noteColor == keyPressed)
        {
            note.OnPressed(transform);
            OnGetPoints(10);
        }
    }

    private void OnGetPoints(int points)
    {
        _points += points;
        pointsText.text = _points.ToString();
    }

}
