using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    public enum SetAnimation
    {
        idle,
        
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
        right,
        none
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

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            actualMovement = setMovement.none;
        }

        print("Horizontal" + Input.GetAxis("Horizontal") + "  "+ "Vertical" + Input.GetAxis("Vertical"));

        switch (actualMovement)
        {
            case setMovement.none:
                actualAnimation = SetAnimation.idle;
                break;
            case setMovement.up:
                actualAnimation = SetAnimation.walkBack;
                break;
            case setMovement.down:
                actualAnimation = SetAnimation.walkFront;
                break;
            case setMovement.left:
                actualAnimation = SetAnimation.walkLeft;
                break;
            case setMovement.right:
                actualAnimation = SetAnimation.walkRight;
                break;
        }
        
        switch (actualAnimation)
        {
            case SetAnimation.idle:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("IdleFront")    || 
                    !anim.GetCurrentAnimatorStateInfo(0).IsName("IdleBack")     || 
                    !anim.GetCurrentAnimatorStateInfo(0).IsName("IdleLeft")     || 
                    !anim.GetCurrentAnimatorStateInfo(0).IsName("IdleRight"))
                {
                    anim.SetTrigger("Idle");
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
            case SetAnimation.walkLeft:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft"))
                {
                    anim.SetTrigger("WalkLeft");
                }
                break;
            case SetAnimation.walkRight:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkRight"))
                {
                    anim.SetTrigger("WalkRight");
                }
                break;
        }
	}
}
