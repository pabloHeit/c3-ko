using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectHitbox : MonoBehaviour
{
    [SerializeField] public bool touch=false;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {

        Note note = other.gameObject.GetComponent<Note>();

        
        touch=true;
        
    }
}
