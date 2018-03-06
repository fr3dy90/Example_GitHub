using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo_1 : MonoBehaviour 
{
    public GameObject casa;
    public GameObject[] objetos;

    private void Start()
    {
        objetos = new GameObject[20];
        for (int i=0; i<20; i++)
        {
            objetos[i] = casa;
        }
    }
}
