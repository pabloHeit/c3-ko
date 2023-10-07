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
    public Colors noteColor;



    [Header("Components")]
    private Rigidbody2D _noteRb;   

     private void Awake()
    {
        _noteRb = GetComponent<Rigidbody2D>();
        _noteRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }

    private void Start() {
        Vector2 direction = Vector2.left;
        _noteRb.velocity = direction * _speed;
    }

    public void OnPressed(Transform inputPosition){

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
