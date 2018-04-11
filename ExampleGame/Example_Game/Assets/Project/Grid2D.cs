using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public int x;
    public int y;
    public GameObject grid(int x, int y)
    {
        GameObject go = new GameObject("Grid");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                point.name = (i.ToString()+"_"+j.ToString());
                point.transform.parent = go.transform;
                point.transform.position = new Vector2(i, j);
                balls[i, j] = point;
            }
        }
        return go;
    }

    public static GameObject[,] balls;

    private void Start()
    {
        balls = new GameObject[x, y];
        GameObject go = grid(x,y);
    }
}
