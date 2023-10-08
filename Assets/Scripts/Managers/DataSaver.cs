using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    private int _points;
    public int totalNoteQuantity;

    public void SetPoints(int points)
    {
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }
}
