using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovParabola : MonoBehaviour {

    public int angle;
    public float res;
    public float disx;
    public float t;

	// Use this for initialization
	void Start () {
        res = Mathf.Cos(angle);
        t = disx * res;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
