using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour {

    public bool simulate;
    public GameObject proyectile;
    public Vector2 proyectilePos;
    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -9.8f);
    public float t;

    public bool hit;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        proyectile.transform.position = proyectilePos;
        rb = proyectile.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (simulate)
        {
            velocity += gravity*Time.deltaTime;
            proyectilePos += velocity*Time.deltaTime;
            proyectile.transform.position = proyectilePos;
            t -= Time.deltaTime;
            if (t <= 0)
            {
                simulate = false;
            }
        }
        if (hit)
        {
            hit = false;
            rb.useGravity = true;
            rb.AddForce(velocity, ForceMode.Impulse);
        }
    }
}
