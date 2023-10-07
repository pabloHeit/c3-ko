using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject nota;
    [SerializeField] float Timer;
    [SerializeField] int index = 1;

    [SerializeField] private TextAsset _textFile;
    private Dictionary<int, float> miDiccionario = new Dictionary<int, float>();


    void Start()
    {
        ConvertTxtToDictionary();
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if(miDiccionario[index] == Mathf.Floor(Timer))
        {
            index++;
            Instantiate (nota,transform.position,transform.rotation);            
        }
    }

    private void ConvertTxtToDictionary()
    {
        // Fijáte de que se haya asignado un archivo de texto en el Inspector
        if (_textFile != null)
        {
            string[] lines = _textFile.text.Split('\n');

            foreach (string line in lines)
            {
                string[] keyValue = line.Trim().Split(':');
                if (keyValue.Length == 2)
                {
                    int key = int.Parse(keyValue[0].Trim());
                    float value = float.Parse(keyValue[1].Trim());
                    miDiccionario[key] = value;
                }
            }

            miDiccionario[miDiccionario.Count + 1] = -1;

            foreach (KeyValuePair<int, float> kvp in miDiccionario)
            {
                Debug.Log("Clave: " + kvp.Key + ", Valor: " + kvp.Value);
            }
        }
        else
        {
            Debug.LogError("No se asignó un archivo de texto.");
        }
    }
}
