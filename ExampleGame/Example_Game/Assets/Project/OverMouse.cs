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
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
        {
            if (hit.transform.name != " ")
            {
                Light((int)hit.transform.position.x, (int)hit.transform.position.y);
            }
        }
    }

    void Light(int x, int y)
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
        if (x >= 0 && x < Grid2D.balls.GetLength(0) && y >= 0 && y < Grid2D.balls.GetLength(1))
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
            if( lefth(x, y, Color.red) >= 3)
            {
                print("Gana jugador 1 Izq");
            }
            else if (right(x, y, Color.red) >= 3)
            {
                print ("Gana jugador 1 Der");
            }else if(lefth(x, y, Color.red)+ right(x, y, Color.red) >= 3)
            {
                print("Gana jugador 1 Suma");
            }

            if(dru(x,y,Color.red) >= 3)
            {
                print("Gana jugaodr 1 DRU");
            }
            else if (dld(x, y, Color.red) >= 3)
            {
                print("Gana jugador 1 DLD");
            }
            else if(dru(x, y, Color.red)+ dld(x, y, Color.red) >= 3)
            {
                print("Gana jugador 1 suma ru+ld");
            }

            if (dlu(x, y, Color.red)>= 3)
            {
                print("Gana Jugador 1 dlu");
            }
            else if (drd(x, y, Color.red) >= 3)
            {
                print("Gana Jugador 1 drd");
            }
            else if (dlu(x, y, Color.red)+ drd(x, y, Color.red)>= 3)
            {
                print("Gana jugador 1 Suma lu+rd");
            }

            if (up(x, y, Color.red) >= 3)
            {
                print("Gana Jugador 1 up");
            }
            else if (down(x, y, Color.red) >= 3)
            {
                print("Gana Jugador 1 down");
            }
            else if (up(x, y, Color.red) + down(x, y, Color.red) >= 3)
            {
                print("Gana jugador 1 Suma vertical");
            }
        }
        else
        {
            Grid2D.balls[x, y].GetComponent<Renderer>().material.color = Color.blue;
            if (lefth(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 Izq");
            }
            else if (right(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 Der");
            }
            else if (lefth(x, y, Color.blue) + right(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 Suma");
            }

            if (dru(x, y, Color.blue) >= 3)
            {
                print("Gana jugaodr 2 DRU");
            }
            else if (dld(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 DLD");
            }
            else if (dru(x, y, Color.blue) + dld(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 suma ru+ld");
            }

            if (dlu(x, y, Color.blue) >= 3)
            {
                print("Gana Jugador 2 dlu");
            }
            else if (drd(x, y, Color.blue) >= 3)
            {
                print("Gana Jugador 2 drd");
            }
            else if (dlu(x, y, Color.blue) + drd(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 Suma lu+rd");
            }

            if (up(x, y, Color.blue) >= 3)
            {
                print("Gana Jugador 2 up");
            }
            else if (down(x, y, Color.blue) >= 3)
            {
                print("Gana Jugador 2 down");
            }
            else if (up(x, y, Color.blue) + down(x, y, Color.blue) >= 3)
            {
                print("Gana jugador 2 Suma vertical");
            }
        }
    }

    public int lefth(int x, int y, Color col)
    {
        int cant = 0;
        while( x > 0)
        {
            x--;
            if(Grid2D.balls[x,y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int right(int x, int y, Color col)
    {
        int cant = 0;
        while(x < Grid2D.balls.GetLength(0))
        {
            x++;
            if(Grid2D.balls[x,y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int dru(int x, int y, Color col)
    {
        int cant = 0;
        while(x<Grid2D.balls.GetLength(0) && y<Grid2D.balls.GetLength(1))
        {
            x++;
            y++;
            if (Grid2D.balls[x,y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int dld(int x, int y, Color col)
    {
        int cant = 0;
        while(x>0 && y> 0)
        {
            x--;
            y--;
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int dlu(int x, int y, Color col)
    {
        int cant = 0;
        while(x>0 && y < Grid2D.balls.GetLength(1))
        {
            x--;
            y++;
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int drd(int x, int y, Color col)
    {
        int cant = 0;
        while (x < Grid2D.balls.GetLength(1) && y > 0 )
        {
            x++;
            y--;
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int up(int x, int y, Color col)
    {
        int cant = 0;
        while(y < Grid2D.balls.GetLength(1))
        {
            y++;
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }

    public int down(int x, int y, Color col)
    {
        int cant = 0;
        while (y > 0)
        {
            y--;
            if (Grid2D.balls[x, y].GetComponent<Renderer>().material.color == col)
            {
                cant++;
            }
            else
            {
                break;
            }
        }
        return cant;
    }
}
