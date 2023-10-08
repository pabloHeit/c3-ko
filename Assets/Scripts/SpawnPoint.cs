using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject blue;
    [SerializeField] GameObject violet;
    [SerializeField] GameObject red;
    [SerializeField] GameObject green;
    [SerializeField] GameObject holdNote;
    [SerializeField] GameObject currentObject;

    [SerializeField] private TextAsset _textFile;
    private Dictionary<int, (int, float, int)> miDiccionario = new Dictionary<int, (int, float, int)>();
    Colors colors;
    private AudioSource audioSource;

    [SerializeField] float Timer;
    [SerializeField] int index = 1;
    [SerializeField] float yPosition;

    void Start()
    {
        ConvertTxtToDictionary();

            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckNoteSpawn();
    }

    private void CheckNoteSpawn()
    {
        float songTime = audioSource.time;

        // Asegúrate de que el índice esté dentro del rango del diccionario.
        if (index > 0 && index <= miDiccionario.Count)
        {
            int noteNum = miDiccionario[index].Item1;
            float noteTimer = miDiccionario[index].Item2;
            int noteType = miDiccionario[index].Item3;
            
            // Ajusta el margen de tiempo permitido para la aparición de la nota.
            if (Mathf.Abs(songTime - noteTimer) < 0.1f)
            {
                SpawnNote(noteNum, noteTimer, noteType);
            }
            else
            {
                print(songTime- noteTimer);
                print(songTime);
                print(noteTimer);
            }
        }
    }

    private void SpawnNote(int noteNum, float noteTimer, int noteType)
    {
        print($"Note: {noteNum}");

        if (noteType == 2)
        {
            currentObject = holdNote;
        }
        else
        {
            switch (noteNum)
            {
                case 1:
                    currentObject = blue;
                    break;
                case 2:
                    currentObject = violet;
                    break;
                case 3:
                    currentObject = red;
                    break;
                case 4:
                    currentObject = green;
                    break;
                default:
                    print($"Error: Valor de nota invalido: {noteNum}");
                    break;
            }
        }

        switch (colors)
        {
            case Colors.Blue:
                // yPosition = ;
                break;
            case Colors.Violet:
                // yPosition = ;
                break;
            case Colors.Red:
                // yPosition = ;
                break;
            case Colors.Green:
                // yPosition = ;
                break;
            default:
                print($"Error: no esta puesto el color de enum");
                break;
        }

        Instantiate(currentObject, transform.position, transform.rotation);
        // cuando tengamos los carriles cambiar el transform.position por yPosition

        index++;  // Incrementa el índice después de SpawnNote
    }

    private void ConvertTxtToDictionary()
    {
        if (_textFile != null)
        {
            string[] lines = _textFile.text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                int keyQuantity = lines.Length;
                string[] keyValue = lines[i].Trim().Split('/');

                if (keyValue.Length == 3)
                {
                    int noteColor = int.Parse(keyValue[0].Trim());
                    float noteTime = float.Parse(keyValue[1].Trim());
                    int noteType = int.Parse(keyValue[2].Trim());
                    miDiccionario[i + 1] = (noteColor, noteTime, noteType);
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
            Debug.LogError("No se asignó un archivo de texto.");
        }
    }
}