using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject nota;
    [SerializeField] float Timer;
    [SerializeField] int index =1;

    [SerializeField]private Dictionary<int, float> miDiccionario = new Dictionary<int, float>();

    // Start is called before the first frame update
    void Start()
    {
        miDiccionario.Add(1, 5);
        miDiccionario.Add(2, 7);
        miDiccionario.Add(3, 9);
        miDiccionario.Add(4, miDiccionario.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer+=Time.deltaTime;
        if(Mathf.Floor(Timer)==5)
        {
            
        }
        if(miDiccionario[index] == Mathf.Floor(Timer))
        {
            index++;
            Instantiate (nota,transform.position,transform.rotation);
            
        }
    }
}
