using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;
    public Vector2 dir;
	
	// Update is called once per frame
	void Update ()
    {
		if(dir  != Vector2.zero)
        {
            MoveBullet(dir);
        }
	}

    void MoveBullet(Vector2 bulletDir)
    {
        transform.Translate(bulletDir * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            target.GetComponentInParent<BasicEnemy>().Die();
            gameObject.SetActive(false);
        }   
    }
}
