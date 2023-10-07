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
    private Dictionary<int, (int, float)> miDiccionario = new Dictionary<int, (int, float)>();


    void Start()
    {
        ConvertTxtToDictionary();
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if(miDiccionario[index].Item2 == Mathf.Floor(Timer))
        {
            SpawnNote(miDiccionario[index].Item1);
        }
    }

    private void SpawnNote(int noteNum)
    {
        print($"Note: {noteNum}");

        switch (noteNum)
        {
            case 1:
                Instantiate(nota, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(nota, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(nota, transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(nota, transform.position, transform.rotation);
                break;
            default:
                print($"Error: Valor de nota invalido: {noteNum}");
                break;
        }
        index++;
    }

    private void ConvertTxtToDictionary()
    {
        // Fijáte de que se haya asignado un archivo de texto en el Inspector
        if (_textFile != null)
        {
            //lines = [ ['noteColor, noteTime'] ]
            string[] lines = _textFile.text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                int keyQuantity = lines.Length;
                string[] keyValue = lines[i].Trim().Split(',');

                if (keyValue.Length == 2)
                {
                    int noteColor = int.Parse(keyValue[0].Trim());
                    float noteTime = float.Parse(keyValue[1].Trim());

                    miDiccionario[i+1] = (noteColor, noteTime);
                }
            }

            miDiccionario[miDiccionario.Count + 1] = (-1, -1);

            Debug.Log("Notas musicales: ");
            foreach (KeyValuePair<int, (int, float)> kvp in miDiccionario)
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
