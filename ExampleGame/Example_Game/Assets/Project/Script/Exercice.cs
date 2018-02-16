using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice : MonoBehaviour {

    public int x;
    public int y;
    int controlCiclo;
    public Material material;

    [System.Serializable]
    public class CLass_a
    {
        public GameObject[] m_material;
    }
    public CLass_a[] class_a;

    private void Start()
    {
        controlCiclo = 0;
        CrearArray();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //ChangeColor();
            ChangeColor_V2();
        }
    }

    void CrearArray()
    {
        class_a = new CLass_a[y];
        for (int i=0; i<y; i++)
        {
            class_a[i] = new CLass_a();
            class_a[i].m_material = new GameObject[x];
            for (int j = 0; j < x; j++)
            {
                int color = Random.Range(0, 4);
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
                obj.transform.position = new Vector3(j, i, 0);
                switch (color)
                {
                    case 0:
                        obj.GetComponent<Renderer>().material.color = Color.red;
                        break;
                    case 1:
                        obj.GetComponent<Renderer>().material.color = Color.blue;
                        break;
                    case 2:
                        obj.GetComponent<Renderer>().material.color = Color.yellow;
                        break;
                    case 3:
                        obj.GetComponent<Renderer>().material.color = Color.green;
                        break;
                }
                class_a[i].m_material[j] = obj;
            }
            controlCiclo++;
        }
    }

    //void ChangeColor()
    //{
    //    for (int i = 0; i < y; i++)
    //    {
    //        for (int j = 0; j < x; j++)
    //        {
    //           if(j > 0)
    //            {
    //                if(class_a[i].m_material[j-1].color == class_a[i].m_material[j].color)
    //                {
    //                    class_a[i].m_material[j - 1] = material;
    //                    class_a[i].m_material[j] = material;
    //                }
    //            }
    //        }
    //    }
    //}

    void ChangeColor_V2()
    {
        Color oldColor;
        for (int i = 0; i < y; i++)
        {
            oldColor = class_a[i].m_material[0].GetComponent<Renderer>().material.color;
            for (int j = 0; j < x; j++)
            {
                if (j > 0)
                {
                    if(class_a[i].m_material[j].GetComponent<Renderer>().material.color == oldColor)
                    {
                        oldColor = class_a[i].m_material[j].GetComponent<Renderer>().material.color;
                        class_a[i].m_material[j - 1].GetComponent<Renderer>().material = material;
                        class_a[i].m_material[j].GetComponent<Renderer>().material =  material; 
                    }
                    else
                    {
                        oldColor = class_a[i].m_material[j].GetComponent<Renderer>().material.color;
                    }
                }
            }
        }
    }
}
