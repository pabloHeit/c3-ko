using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Note : MonoBehaviour
{    
    [Header("Values")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] public bool _isActive = true;

    [Header("Slider")]
    [SerializeField] private bool _isSlider;
    private Transform _sliderEraser;
    [SerializeField] private float _sliderEraserSize;
    public NoteDirection noteDirection;
    [SerializeField] private bool hasStarted;
    [SerializeField] private float beatTempo;

    [Header("Components")]
    private Rigidbody2D _noteRb;   
    
    private void Start() {
        beatTempo = beatTempo/60;
    }

    void Update () 
    {
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
    }

    public void OnPressed(Transform inputPosition)
    {

        if (!_isSlider)
        {
            Destroy(gameObject);
            return;
        }

        _sliderEraser = transform.GetChild(0);

        _sliderEraser.position = new Vector3(inputPosition.position.x, 0, 0);

        SpriteRenderer sliderSprite = _sliderEraser.GetComponent<SpriteRenderer>();
        _sliderEraserSize += - _speed * Time.deltaTime;
        sliderSprite.size = new Vector2(_sliderEraserSize, 0.19f);

    }
}
