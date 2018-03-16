using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour {

    public bool simulate;
    public GameObject proyectile;
    public Vector2 proyectilePos;
    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -9.8f);

    public bool hit;
    Rigidbody rb;

    public int res;
    public Vector2[] points;
    public float timeSimulate;

	// Use this for initialization
	void Start ()
    {
        proyectile.transform.position = proyectilePos;
        rb = proyectile.GetComponent<Rigidbody>();
        points = new Vector2[res];
    }
	
	// Update is called once per frame
	void Update () {
        if (simulate)
        {
            velocity += gravity*Time.deltaTime;
            proyectilePos += velocity*Time.deltaTime;
            proyectile.transform.position = proyectilePos;
            timeSimulate -= Time.deltaTime;
            if (timeSimulate <= 0)
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
        Calculate();
    }

    void Calculate()
    {
        Vector2 refVel = velocity;
        Vector2 refG = gravity;
        for (int i = 0; i < res; i++)
        {
            float t = i / (float)res*timeSimulate;
            Vector2 desp = refVel * t + refG * t * t / 2f;
            points[i] = desp;
            if (i > 0)
            {

                Debug.DrawLine(points[i], points[i-1], Color.green);
            }
        }
    }
}
