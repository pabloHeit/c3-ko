using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inputs : MonoBehaviour
{
    [Header("Inputs")]
    private KeyCode key = KeyCode.Space;

    [SerializeField]private KeyCode _downKeycode;
    [SerializeField]private KeyCode _upKeycode;
    [SerializeField]private KeyCode _rightKeycode;
    [SerializeField]private KeyCode _leftKeycode;

    [SerializeField] private int _points;

    [SerializeField] TextMeshProUGUI pointsText;

    [SerializeField] private bool _onCollision = false;
    [SerializeField] private bool _hasPressed = false;
    private PerfectHitbox perfect;
    private TimingSign sign;
    [SerializeField] NoteDirection keyPressed;

    [SerializeField] private PlayerAnimations _playerAnimations;

    private void Awake() {
        perfect = FindObjectOfType<PerfectHitbox>();
        sign = FindObjectOfType<TimingSign>();

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
        
        if (Input.GetKey(_downKeycode))
        {
           keyPressed=NoteDirection.Down;
            _hasPressed = true;
           return;
        }
        if(Input.GetKey(_upKeycode))
        {
           keyPressed=NoteDirection.Up;
            _hasPressed = true;
            return;
        }
        if(Input.GetKey(_rightKeycode))
        {
            keyPressed=NoteDirection.Right;
            _hasPressed = true;
            return;
        }   
        if(Input.GetKey(_leftKeycode))
        {
            keyPressed=NoteDirection.Left;
            _hasPressed = true;
            return;
        }

        /*if (keyPressed !=NoteDirection.none)
        {
            _playerAnimations.ChangeAnimation(keyPressed);
            print("asd");
        }*/
        keyPressed =NoteDirection.none;
        _hasPressed = false;

    }
    private void OnTriggerStay2D(Collider2D other) {

        Note note = other.gameObject.GetComponent<Note>();
        if (note)
        {
            _onCollision = true;

            if (_hasPressed && note._isActive)
            {
                if(note.noteDirection == keyPressed)
                {
                    if(perfect.touch)
                    {
                        OnGetPoints(30);
                        sign.ChangeSprite(sign.perfect);
                    }
                    else
                    {
                        OnGetPoints(15);
                        sign.ChangeSprite(sign.good);
                    }
                    perfect.touch=false;
                    note.OnPressed(transform);

                    _playerAnimations.ChangeAnimation(keyPressed);
                }
                else
                {
                    OnLosePoints(10);
                    note._isActive = false;
                    _playerAnimations.ChangeAnimation(keyPressed, true);
                }
                keyPressed = NoteDirection.none;
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
