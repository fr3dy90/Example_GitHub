using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverMouse : MonoBehaviour
{
    public bool isPlayerOne;

    private void Start()
    {
        isPlayerOne = false;
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
        {
            if(hit.transform.name != " ")
            {
                Light((int)hit.transform.position.x, (int)hit.transform.position.y);
            }
        }
    }

    void Light(int x,  int y)
    {
        for (int i = 0; i < Grid2D.balls.GetLength(0); i++)
        {
            for (int j = 0; j < Grid2D.balls.GetLength(1); j++)
            {
                if (Grid2D.balls[i, j].GetComponent<Renderer>().material.color != Color.red 
                    && Grid2D.balls[i, j].GetComponent<Renderer>().material.color != Color.blue)
                {
                    Grid2D.balls[i, j].GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
        if(x >= 0 && x < Grid2D.balls.GetLength(0) && y >= 0 && y < Grid2D.balls.GetLength(1))
        {
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color != Color.red
                    && Grid2D.balls[x, y].GetComponent<Renderer>().material.color != Color.blue)
            {
                Grid2D.balls[x, y].GetComponent<Renderer>().material.color = Color.yellow;
                if (Input.GetMouseButtonDown(0))
                {
                    PlayPlayer(x, y);
                }
            }
        }
    }

    void PlayPlayer(int x, int y)
    {
        isPlayerOne = !isPlayerOne;
        if (isPlayerOne)
        {
            Grid2D.balls[x, y].GetComponent<Renderer>().material.color = Color.red;
            if (right(x, y, Color.red) >= 4)
            {
                print("jugador 1 gana");
            }
            else if (lefht(x,y,Color.red) >= 3)
            {
                print("Gana Jugador 1");
            }
            else if(lefht(x, y, Color.red)+ right(x, y, Color.red) >= 3)
            {
                print("Gana Jugador 1");
            }
        }
        else
        {
            Grid2D.balls[x, y].GetComponent<Renderer>().material.color = Color.blue;
            if (right(x, y, Color.blue) >= 4)
            {
                print("jugador 2 Gana");
            }
            else if (lefht(x,y,Color.blue) >= 3)
            {
                print("Gana Jugador 2");
            }
            else if (right(x, y, Color.blue) + lefht(x, y, Color.blue) >= 3)
            {
                print("Gana Jugador 2");
            }
        }
    }

    public int right(int x, int y, Color col)
    {
        int cant = 0;
        for(int i=x; i<x+3; i++)
        {
            if(i < Grid2D.balls.GetLength(0))
            {
                if(Grid2D.balls[i,y].GetComponent<Renderer>().material.color == col)
                {
                    cant++;
                }
                else
                {
                    cant = 0;
                }
            }
        }
        return cant;
    }

    public int lefht(int x, int y, Color col)
    {
        int cant = 0;
        for (int i = x-4; i<x; i++)
        {
            if (i >= 0)
            {
                if(Grid2D.balls[i,y].GetComponent<Renderer>().material.color == col)
                {
                    cant++;
                }
                else
                {
                    cant = 0;
                }
            }
        }
        return cant;
    }
}
