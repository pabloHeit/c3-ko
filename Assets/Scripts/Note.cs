using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Note : MonoBehaviour
{    
    [Header("Values")]
    [SerializeField] private float speed = 3f;

    [Header("Components")]
    private Rigidbody2D noterb;
   

     private void Awake()
    {
        noterb = GetComponent<Rigidbody2D>();
        noterb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }

    private void Start() {
        Vector2 direction = Vector2.left;
        noterb.velocity = direction * speed;
    }

    public void Destroy(){
        Destroy(gameObject);
    }
}
