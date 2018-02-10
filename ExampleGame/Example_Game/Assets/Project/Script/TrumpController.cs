using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    public enum SetAnimation
    {
        idleFront,
        idleBack,
        idleRight,
        idleLeft,

        walkFront,
        walkBack,
        walkRight,
        walkLeft,

        runFront,
        runBack,
        runRight,
        runLeft
    }
    public SetAnimation actualAnimation;

    public enum setMovement
    {
        up,
        down,
        left,
        right
    }
    public setMovement actualMovement;

    Animator anim;
    string last;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update () {
        
        if(Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                actualMovement = setMovement.right;
                last = "right";
            }else if(Input.GetAxis ("Horizontal") < 0)
            {
                actualMovement = setMovement.left;
                last = "left";
            }
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                actualMovement = setMovement.up;
                last = "up";
            }else if(Input.GetAxis("Vertical") < 0)
            {
                actualMovement = setMovement.down;
                last = "down";
            }
        }


        
        
        switch (actualAnimation)
        {
            case SetAnimation.idleFront:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("IdleFront"))
                {
                    anim.SetTrigger("WalkFront");
                }
                break;
            case SetAnimation.walkFront:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkFront"))
                {
                    anim.SetTrigger("WalkFront");
                }
                break;
            case SetAnimation.walkBack:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkBack"))
                {
                    anim.SetTrigger("WalkBack");
                }
                break;
        }
	}
}
