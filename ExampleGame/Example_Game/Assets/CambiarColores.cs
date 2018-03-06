using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColores : MonoBehaviour 
{
    public bool revisar;
    [HideInInspector]
    public bool seguro;
    [HideInInspector]
    public int columnas;
    public int filas;
    public GameObject[] esferas;

	void Start () 
	{
        seguro = true;
	}
	
	void Update () 
	{
        if(revisar && seguro && esferas.Length > 0)
        {
            seguro = false;
            CambiarColorEsfera();
        }		
	}

    void CambiarColorEsfera()
    {
        //Material materialViejo;
        int pos = 0;
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (pos > (columnas*i))
                {
                    if (esferas[pos - 1].GetComponent<Renderer>().material.color ==
                        esferas[pos].GetComponent<Renderer>().material.color)
                    {
                        esferas[pos - 1].GetComponent<Renderer>().material.color = Color.black;
                        esferas[pos].GetComponent<Renderer>().material.color = Color.black;
                    }
                }
                pos++;
            }
        }
    }
}
