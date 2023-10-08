using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject _down;
    [SerializeField] GameObject _up;
    [SerializeField] GameObject _right;
    [SerializeField] GameObject _left;
    [SerializeField] GameObject holdNote;
    [SerializeField] GameObject currentObject;

    [SerializeField] private TextAsset _textFile;
    private Dictionary<int, (int, float, int)> miDiccionario = new Dictionary<int, (int, float, int)>();
    private NoteDirection _noteType;
    [SerializeField] private SoundManager audioSource;

    [SerializeField] float Timer;
    [SerializeField] int index = 1;
    [SerializeField] float yPosition;

    private float realTime = 0;
    private float timeToReachInput;

    private bool _isPlaying = false;

    private float travelDistance = 0;

    [SerializeField] private Transform _input;

    private DataSaver _dataSaver;


    void Start()
    {
        _dataSaver = GameObject.FindGameObjectWithTag("DataSaver").GetComponent<DataSaver>();
        
        ConvertTxtToDictionary();

        travelDistance = Mathf.Ceil(transform.position.x) - Mathf.Floor(_input.position.x);
        timeToReachInput = travelDistance / _down.GetComponent<Note>().GetSpeed()  - 0.5f;

    }


    void Update()
    {
        realTime += Time.deltaTime;

        CheckNoteSpawn();
        //print($"realTime: {realTime}");
        //print($"timeToReachInput: {timeToReachInput}");

        if (realTime >= timeToReachInput)
        {
            if (audioSource.GetPlayTime() == 0 && !_isPlaying)
            {
                _isPlaying = true;
                audioSource.GetComponent<AudioSource>().Play();
            }
        }

        if (index >= _dataSaver.totalNoteQuantity)
        {
            if (realTime >= (timeToReachInput + travelDistance * 3))
            {
                EndGame();
            }
        }
    }
    private void EndGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    private void CheckNoteSpawn()
    {

        // Asegúrate de que el índice esté dentro del rango del diccionario.
        if (index <= 0 || index > miDiccionario.Count)
        {
            return;
        }

        int noteNum = miDiccionario[index].Item1;
        float noteTimer = miDiccionario[index].Item2;
        int noteType = miDiccionario[index].Item3;
            
        // Ajusta el margen de tiempo permitido para la aparición de la nota.
        if (realTime >= noteTimer)
        {
            print(noteTimer);
            SpawnNote(noteNum, noteTimer, noteType);
        }
        else
        {
            /*print($"SongTime - note timer: {songTime- noteTimer}");
            print($"SongTime: {songTime}");
            print($"SongTime: {noteTimer}");*/
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
                    currentObject = _down;
                    break;
                case 2:
                    currentObject = _up;
                    break;
                case 3:
                    currentObject = _right;
                    break;
                case 4:
                    currentObject = _left;
                    break;
                default:
                    print($"Error: Valor de nota invalido: {noteNum}");
                    break;
            }
        }

        /*switch (_noteType)
        {
            case NoteDirection.Blue:
                // yPosition = ;
                break;
            case NoteDirection.Violet:
                // yPosition = ;
                break;
            case NoteDirection.Red:
                // yPosition = ;
                break;
            case NoteDirection.Green:
                // yPosition = ;
                break;
            default:
                print($"Error: no esta puesto el color de enum");
                break;
        }*/

        Instantiate(currentObject, transform.position, transform.rotation);
        // cuando tengamos los carriles cambiar el transform.position por yPosition

        index++;  // Incrementa el índice después de SpawnNote
    }

    private void ConvertTxtToDictionary()
    {
        if (_textFile != null)
        {
            string[] lines = _textFile.text.Split('\n');

            int indexReal = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i].Trim()))
                {
                    continue;
                }

                string[] keyValue = lines[i].Trim().Split('/');

                if (keyValue.Length == 3)
                {
                    int noteDirection = int.Parse(keyValue[0].Trim());
                    float noteTime = float.Parse(keyValue[1].Trim());
                    //noteTime = GetRealNoteTime(noteTime);
                    int noteType = int.Parse(keyValue[2].Trim());
                    miDiccionario[indexReal] = (noteDirection, noteTime, noteType);

                }

                indexReal++;
            }

            miDiccionario[miDiccionario.Count + 1] = (-1, -1, 1);

            //gUARDAR cantidad de notas
            _dataSaver.totalNoteQuantity = miDiccionario.Count;

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

    private float GetRealNoteTime(float originalNoteTime)
    {
        float travelDistance = transform.position.x - _input.position.x;
        float timeToInput = travelDistance / _down.GetComponent<Note>().GetSpeed();

        float realNoteTime = originalNoteTime ;

        return realNoteTime;
    }
}