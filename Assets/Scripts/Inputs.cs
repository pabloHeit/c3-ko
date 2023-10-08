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
    [SerializeField] private bool isOnInput;

    [SerializeField] TextMeshProUGUI pointsText;

    [SerializeField] private bool _onCollision = false;
    [SerializeField] private bool _hasPressed = false;
    private PerfectHitbox perfect;
    private TimingSign sign;
    private SpriteHits hits;
    [SerializeField] NoteDirection keyPressed;
    private Note note;

    [SerializeField] private PlayerAnimations _playerAnimations;

    [Header("Sounds")]
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioClip _missedSound;
    [SerializeField] private AudioClip _goodSound;
    [SerializeField] private AudioClip _perfectSound;

    [SerializeField] private Animator _enemyAnimator;


    private void Awake() {
        perfect = FindObjectOfType<PerfectHitbox>();
        sign = FindObjectOfType<TimingSign>();
        hits = FindObjectOfType<SpriteHits>();
    }

    private void Update(){
        
        InputKeys();
        Comprobation();
    }

    private void InputKeys()
    {
        if (Input.GetKeyDown(_downKeycode))
        {
           keyPressed=NoteDirection.Down;
            _hasPressed = true;
           return;
        }
        if(Input.GetKeyDown(_upKeycode))
        {
           keyPressed=NoteDirection.Up;
            _hasPressed = true;
            return;
        }
        if(Input.GetKeyDown(_rightKeycode))
        {
            keyPressed=NoteDirection.Right;
            _hasPressed = true;
            return;
        }   
        if(Input.GetKeyDown(_leftKeycode))
        {
            keyPressed=NoteDirection.Left;
            _hasPressed = true;
            return;
        }
        keyPressed =NoteDirection.none;
        _hasPressed = false;
    }

    private void Comprobation()
    {
        if(_hasPressed && isOnInput)
        {
            
                if(note.noteDirection == keyPressed)
                {
                    if(perfect.touch)
                    {
                        OnGetPoints(100);
                        sign.ChangeSprite(sign.perfect);
                        hits.ChangeSprite();
                        _soundManager.OnShotHitSound(_perfectSound);

                    }
                    else
                    {
                        OnGetPoints(50);
                        sign.ChangeSprite(sign.good);
                        hits.ChangeSprite();
                        _soundManager.OnShotHitSound(_goodSound);
                    }
                    perfect.touch=false;
                    note.OnPressed(transform);

                    _playerAnimations.ChangeAnimation(keyPressed);
                }
                else
                {
                    OnLosePoints(10);
                    
                    _playerAnimations.ChangeAnimation(keyPressed, true);
                    _soundManager.OnShotHitSound(_missedSound);
                }
                keyPressed = NoteDirection.none;
                _hasPressed = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        note = other.gameObject.GetComponent<Note>();
        if(note)
        {
            isOnInput=true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        note = other.gameObject.GetComponent<Note>();
        if(note)
        {
            isOnInput=false;
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
