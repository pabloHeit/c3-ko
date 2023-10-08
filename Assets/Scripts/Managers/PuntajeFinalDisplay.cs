using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntajeFinalDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;


    private void Awake()
    {
        pointsText = GetComponent<TextMeshProUGUI>();
        DataSaver dataSaver = GameObject.FindGameObjectWithTag("DataSaver").GetComponent<DataSaver>();
        pointsText.text = dataSaver.GetPoints().ToString();
    }
}
