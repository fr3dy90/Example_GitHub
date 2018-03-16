using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour {

    public int q, w, e, r, t, y, u, i, o, p;
    public int z, x;
	// Use this for initialization
	void Start () {
        // Aca se esta imorimiendo en consola
        print("Hola Mundo");
        // Aca se esta haciendo la suma de los literales
        int num_2 = 5 + 7;
        // Aca se esta imorimiendo en consola
        print(num_2);
        // Aca se esta haciendo la suma de las variables
        int num_3 = q + w + e + r + t + y + u + i + o + p;
        // Aca se esta imorimiendo en consola
        print(num_3);
        // Aca se esta sacando el promedio de los literales
        float num_4 = (5 + 7 + 8 + 3) / 4;
        // Aca se esta imorimiendo en consola
        print(num_4);
        // Aca se esta sacando el promedio de las variables
        float num_5 = (num_3 + z + x) / 12;
        // Aca se esta imorimiendo en consola
        print(num_5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
