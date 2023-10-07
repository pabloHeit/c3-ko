using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject nota;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate (nota,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
