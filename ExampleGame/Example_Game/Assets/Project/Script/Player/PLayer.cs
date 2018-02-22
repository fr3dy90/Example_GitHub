using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour {

    public Animator anim;
    public Rigidbody2D rb;
    public bool isGrounded;
    public float movementSpeed;
    public float jump_force;
    public LayerMask collsionLayer;
    public float radius;
    public float jumpTime;
    public float fallTime;
    bool canTrigger;
    Vector2 axesDir;
    public Vector2 right;
    public Vector2 left;
    public bool canMoveLeft;
    public bool isShoot;
    public float timeShoot;
    float wait;
    public Transform spawnBullet;
    public Vector3[] spawnPositions;
    public GameObject bulletPref;
    public Vector2 bulletDir;

    public enum SetAnimation
    {
        lookUp,
        runLeftUp,
        runRightUp,
        idle,
        left,
        right,
        stayDown,
        runLeftDown,
        runRightDown,
        jump,

        idleShoot,
        runShoot
    }
    public SetAnimation actualAnimation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        actualAnimation = SetAnimation.jump;
    }

    private void Update()
    {
        axesDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
        if(fallTime > 0)
        {
            fallTime -= Time.deltaTime;
            GetComponent<Collider2D>().isTrigger = true;
        }
        else if(fallTime <= 0 && canTrigger)
        {
            canTrigger = false;
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (Input.GetButtonDown("Jump") && isGrounded && actualAnimation != SetAnimation.stayDown)
        {
            jumpTime = 0.2f;
            isGrounded = false;
            rb.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
            actualAnimation = SetAnimation.jump;
        }
        else if(Input.GetButtonDown("Jump") && isGrounded && actualAnimation == SetAnimation.stayDown)
        {
            fallTime = 0.2f;
            isGrounded = false;
            rb.AddForce(Vector2.down * jump_force/3, ForceMode2D.Impulse);
            canTrigger = true;
        }
        if (isGrounded && jumpTime <= 0)
        {
            switch ((int)axesDir.x)
            {
                case 0:
                    switch ((int)axesDir.y)
                    {
                        case 0:
                            actualAnimation = SetAnimation.idle;
                            SetBulletDir((int)transform.localScale.x, 0, 0);
                            break;
                        case 1:
                            actualAnimation = SetAnimation.lookUp;
                            SetBulletDir(0, 1, 1);
                            break;
                        case -1:
                            actualAnimation = SetAnimation.stayDown;
                            SetBulletDir((int)transform.localScale.x, 0, 2);
                            break;
                    }
                    break;
                case 1:
                    switch ((int)axesDir.y)
                    {
                        case 0:
                            actualAnimation = SetAnimation.right;
                            SetBulletDir(1, 0, 0);
                            break;
                        case 1:
                            actualAnimation = SetAnimation.runRightUp;
                            SetBulletDir(1, 1, 3);
                            break;
                        case -1:
                            actualAnimation = SetAnimation.runRightDown;
                            SetBulletDir(1, -1, 4);
                            break;
                    }
                    break;
                case -1:
                    switch ((int)axesDir.y)
                    {
                        case 0:
                            actualAnimation = SetAnimation.left;
                            SetBulletDir(-1, 0, 0);
                            break;
                        case 1:
                            actualAnimation = SetAnimation.runLeftUp;
                            SetBulletDir(-1, 1, 3);
                            break;
                        case -1:
                            actualAnimation = SetAnimation.runLeftDown;
                            SetBulletDir(-1, -1, 4);
                            break;
                    }
                    break;
            }
        }
        MovePlayer((int)axesDir.x);

        if (Input.GetButtonDown("Fire1") && !isShoot)
        {
            Fire((int)bulletDir.x, (int)bulletDir.y);
            isShoot = true;
            wait = timeShoot;
        }
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }
        else if (wait < 0 && isShoot)
        {
            isShoot = false;
        }
        if (Input.GetButton("Fire1"))
        {
            isShoot = true;
        }


        switch (actualAnimation)
        {
            case SetAnimation.idle:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    anim.SetTrigger("Idle");
                }
                break;

            case SetAnimation.runLeftUp:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShootUp"))
                {
                    anim.SetTrigger("RunUp");
                }
                transform.localScale = left;
                break;

            case SetAnimation.runRightUp:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShootUp"))
                {
                    anim.SetTrigger("RunUp");
                }
                transform.localScale = right;
                break;

            case SetAnimation.right:
                if (!isShoot)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        anim.SetTrigger("Run");
                    }
                }
                else
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShoot"))
                    {
                        anim.SetTrigger("RunShoot");
                    }
                }
                transform.localScale = right;
                break;

            case SetAnimation.left:
                if (!isShoot)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        anim.SetTrigger("Run");
                    }
                }
                else
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShoot"))
                    {
                        anim.SetTrigger("RunShoot");
                    }
                }
                transform.localScale = left;
                break;

            case SetAnimation.lookUp:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp"))
                {
                    anim.SetTrigger("LookUp");
                }
                break;

            case SetAnimation.stayDown:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("StayDown"))
                {
                    anim.SetTrigger("StayDown");
                }
                break;
            case SetAnimation.runLeftDown:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShootDown"))
                {
                    anim.SetTrigger("RunDown");
                }
                transform.localScale = left;
                break;

            case SetAnimation.runRightDown:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RunShootDown"))
                {
                    anim.SetTrigger("RunDown");
                }
                transform.localScale = right;
                break;

            case SetAnimation.jump:
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    anim.SetTrigger("Jump");
                }
                break;
        }
        isGrounded = (Physics2D.OverlapCircle(transform.position, radius, collsionLayer)&&rb.velocity.y <= 0);
    }

    void SetBulletDir(int x, int y, int pos)
    {
        bulletDir.x = x;
        bulletDir.y = y;
        spawnBullet.localPosition = spawnPositions[pos];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void MovePlayer(int dir)
    {
        if(dir < 0 && !canMoveLeft)
        {
            return;
        }
        transform.Translate((Vector3.right * (Time.deltaTime * movementSpeed)) * dir);
    }

    public void Fire(int x, int y)
    {
        GameObject bullet = Instantiate(bulletPref, spawnBullet.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().dir = new Vector2(x,y);
    }
}