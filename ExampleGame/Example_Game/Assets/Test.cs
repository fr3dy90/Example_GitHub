using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour 
{
    public GameObject[,,] objetos;
    public int filas;
    public int columnas;
    public int profundidad;
    int selector;

    void Start ()
	{
        columnas = Random.Range(3, 13);
        
        objetos = new GameObject[0, columnas, 0];
        Camera.main.transform.position = new Vector3((filas-1)/2f, (columnas-1)/2f, -10f);
        for(int i=0; i< columnas; i++)
        {
            filas = Random.Range(3, 13);
            objetos = new GameObject[filas, columnas, 0];
            for (int j=0; j<filas; j++)
            {
                profundidad = Random.Range(3, 13);
                objetos = new GameObject[filas, columnas, profundidad];
                for (int k = 0; k < profundidad; k++)
                {
                    GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    selector = Random.Range(0, 4);
                    if (selector == 0)
                    {
                        obj.GetComponent<Renderer>().material.color = Color.magenta;
                    }
                    else if (selector == 1)
                    {
                        obj.GetComponent<Renderer>().material.color = Color.yellow;
                    }
                    else if (selector == 2)
                    {
                        obj.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else
                    {
                        obj.GetComponent<Renderer>().material.color = Color.cyan;
                    }
                    obj.transform.position = new Vector3(j, i, k);
                    obj.transform.SetParent(this.transform);
                    objetos[j, i, k] = obj;
                }
            }
        }
    }
	
	void Update () 
	{
		
	}
}
