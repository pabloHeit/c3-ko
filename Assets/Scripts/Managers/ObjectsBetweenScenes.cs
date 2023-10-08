using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        var noDestruirEscenas = FindObjectsOfType<ObjectsBetweenScenes>();
        if (noDestruirEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
