using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearEsferas : MonoBehaviour 
{
    public bool crear;
    bool seguro;
    [SerializeField]
    int columnas;
    [SerializeField]
    int filas;
    public CambiarColores m_cambiarColores;
    
    void Start()
    {
        seguro = true;
        crear = false;
    }

    void Update()
    {
        if(seguro && crear)
        {
            seguro = false;
            CrearMatriz();
        }
        else if(!seguro && !crear && m_cambiarColores.esferas.Length !=0)
        {
            BorrarMatriz(filas, columnas);
        }
    }

    void CrearMatriz()
    {
        columnas = Random.Range(3, 13);
        filas = Random.Range(3, 13);
        m_cambiarColores.esferas = new GameObject[columnas * filas];
        int pos = 0;
        int selectorDeColor; 

        for(int i=0; i<filas; i++)
        {
            for(int j=0; j<columnas; j++)
            {
                GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                esfera.transform.position = new Vector3(j, i, 0);
                selectorDeColor = Random.Range(0, 4);
                if(selectorDeColor == 0)
                {
                    esfera.GetComponent<Renderer>().material.color = Color.green;
                }
                else if(selectorDeColor == 1)
                {
                    esfera.GetComponent<Renderer>().material.color = Color.blue;
                }
                else if (selectorDeColor == 2)
                {
                    esfera.GetComponent<Renderer>().material.color = Color.magenta;
                }
                else
                {
                    esfera.GetComponent<Renderer>().material.color = Color.yellow;
                }
                m_cambiarColores.esferas[pos] = esfera;
                pos++;
            }
        }
        m_cambiarColores.seguro = true;
        m_cambiarColores.revisar = false;
        m_cambiarColores.columnas = columnas;
        m_cambiarColores.filas = filas;
    }

    void BorrarMatriz(int x, int y)
    {
        for(int i=0; i< m_cambiarColores.esferas.Length; i++)
        {
            Destroy(m_cambiarColores.esferas[i]);
        }
        m_cambiarColores.esferas = new GameObject[0];
        seguro = true;
    }
}
