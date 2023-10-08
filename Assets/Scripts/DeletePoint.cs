using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePoint : MonoBehaviour
{
    private Note note;
    [SerializeField] Inputs inputsObject;
    private DataSaver _dataSaver;
    private int _deletedNotes = 0;

    private void Awake() {
        _dataSaver = GameObject.FindGameObjectWithTag("DataSaver").GetComponent<DataSaver>();

        note = GetComponent<Note>();
        //inputsObject = gameObject.GetComponent<Inputs>();
    }



    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.gameObject.GetComponent<Note>())
        {
            _deletedNotes++;
            inputsObject.OnLosePoints(10);
            Destroy(other.gameObject);
        }
    }
}