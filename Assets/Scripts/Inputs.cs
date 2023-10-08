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

    [SerializeField] private bool _onCollision = false;
    [SerializeField] private bool _hasPressed = false;
    private PerfectHitbox perfect;

    [SerializeField] Colors keyPressed;

    private void Awake() {
        perfect = FindObjectOfType<PerfectHitbox>();
    }

    private void Update(){
        //Si dejamos esto en GetKey no va a parar de restar puntos(es muy sensible)
        //Pero si lo ponemos en GetKeyDown directamente le cuesta una bocha en detectar las notas
        //No se me ocurrio que hacer
        /*if (_hasPressed && !_onCollision)
        {
            OnLosePoints(10);
            _hasPressed = false;
        }*/

        if (Input.GetKey(blue))
        {
           keyPressed=Colors.Blue;
            _hasPressed = true;
           return;
        }
        if(Input.GetKey(violet))
        {
           keyPressed=Colors.Violet;
            _hasPressed = true;
            return;
        }
        if(Input.GetKey(red))
        {
            keyPressed=Colors.Red;
            _hasPressed = true;
            return;
        }   
        if(Input.GetKey(green))
        {
            keyPressed=Colors.Green;
            _hasPressed = true;
            return;
        }
        keyPressed=Colors.none;
        _hasPressed = false;

    }
    private void OnTriggerStay2D(Collider2D other) {

        Note note = other.gameObject.GetComponent<Note>();
        if (note)
        {
            _onCollision = true;

            if (_hasPressed && note._isActive)
            {
                if(note.noteColor == keyPressed)
                {
                    note.OnPressed(transform);
                    OnGetPoints(15);
                }
                else
                {
                    OnLosePoints(10);
                    note._isActive = false;
                }
                keyPressed = Colors.none;
                _hasPressed = false;
            }
        }
    }

    public void OnGetPoints(int points)
    {
        _points += points;
        pointsText.text = _points.ToString();
    }

    public void OnLosePoints(int points)
    {
        _points -= points;
        pointsText.text = _points.ToString();
    }

}
