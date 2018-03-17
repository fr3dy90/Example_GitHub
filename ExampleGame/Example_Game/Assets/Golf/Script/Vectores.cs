using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour {

    public bool simulate;
    public GameObject proyectile;
<<<<<<< HEAD
    public Vector2 proyectilePos;
    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -9.8f);
    public float t;
=======
    Vector3 initPos;
    public Vector3 proyectilePos;
    public Vector3 velocity;
    public Vector3 gravity = new Vector3(0, -9.8f, 0);
>>>>>>> 6781a7a4d7b1d73b25a449f48f003514a41d84ab

    public bool hit;
    Rigidbody rb;

    public int res;
    public Vector3[] points;
    public float timeSimulate;

    LineRenderer lr;

	// Use this for initialization
	void Start ()
    {
        lr = GetComponent<LineRenderer>();
        initPos = proyectile.transform.position;
        proyectile.transform.position = proyectilePos;
        rb = proyectile.GetComponent<Rigidbody>();
        points = new Vector3[res];
    }
	
	// Update is called once per frame
	void Update () {
        if (simulate)
        {
            velocity += gravity*Time.deltaTime;
            proyectilePos += velocity*Time.deltaTime;
            proyectile.transform.position = proyectilePos;
<<<<<<< HEAD
            t -= Time.deltaTime;
            if (t <= 0)
=======
            timeSimulate -= Time.deltaTime;
            if (timeSimulate <= 0)
>>>>>>> 6781a7a4d7b1d73b25a449f48f003514a41d84ab
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
        Vector3 refVel = velocity;
        Vector3 refG = gravity;
        
        for (int i = 0; i < res; i++)
        {
            float t = i / (float)res*timeSimulate;
            Vector3 desp = refVel * t + refG * t * t / 2f;
            desp += initPos;
            points[i] = desp;
            if (i > 0)
            {

                Debug.DrawLine(points[i], points[i-1], Color.green);
            }
            lr.SetPositions(points);
        }
    }
}
