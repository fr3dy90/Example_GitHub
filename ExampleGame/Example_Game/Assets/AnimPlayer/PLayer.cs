using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour {

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
                anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("Down", true);
        }
        else
        {
            anim.SetBool("Down", false);
        }
        anim.SetFloat("ShootDir", Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }
    }
}
