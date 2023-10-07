using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject nota;
    [SerializeField] GameObject holdNote;
    [SerializeField] GameObject currentObject;
    [SerializeField] float Timer;
    [SerializeField] int index = 1;
    [SerializeField] float yPosition;

    [SerializeField] private TextAsset _textFile;
    private Dictionary<int, (int, float, int)> miDiccionario = new Dictionary<int, (int, float, int)>();


    void Start()
    {
        ConvertTxtToDictionary();
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if(miDiccionario[index].Item2 == Mathf.Floor(Timer))
        {
            SpawnNote(miDiccionario[index].Item1, miDiccionario[index].Item3);
        }
    }

    private void SpawnNote(int noteNum, int noteType)
    {
        print($"Note: {noteNum}");
        
        switch (noteType)
        {
            case 1:
                currentObject=nota;
                break;
            case 2:
                currentObject=holdNote;
                break;
        }

        switch (noteNum)  // cuando tengamos los carriles hechos hay que cambiar esto
        {
            case 1:
                yPosition=transform.position.y;
                break;
            case 2:
                yPosition=transform.position.y;
                break;
            case 3:
                yPosition=transform.position.y;
                break;
            case 4:
                yPosition=transform.position.y;
                break;
            default:
                print($"Error: Valor de nota invalido: {noteNum}");
                break;
        }
        Instantiate(currentObject, transform.position, transform.rotation);  // cuando tengamos los carriles cambiar el transform.position por yPosition
        index++;
    }

    private void ConvertTxtToDictionary()
    {
        // Fij�te de que se haya asignado un archivo de texto en el Inspector
        if (_textFile != null)
        {
            //lines = [ ['noteColor, noteTime, noteType'] ]
            string[] lines = _textFile.text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                int keyQuantity = lines.Length;
                string[] keyValue = lines[i].Trim().Split(',');

                if (keyValue.Length == 3)
                {
                    int noteColor = int.Parse(keyValue[0].Trim());
                    float noteTime = float.Parse(keyValue[1].Trim());
                    int noteType = int.Parse(keyValue[2].Trim());
                    miDiccionario[i+1] = (noteColor, noteTime, noteType);
                }
            }

            miDiccionario[miDiccionario.Count + 1] = (-1, -1, 1); 

            Debug.Log("Notas musicales: ");
            foreach (KeyValuePair<int, (int, float, int)> kvp in miDiccionario)
            {
                Debug.Log("Clave: " + kvp.Key + ", Valor: " + kvp.Value); 
            }
        }
        else
        {
            Debug.LogError("No se asign� un archivo de texto.");
        }
    }
}
