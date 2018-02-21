using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public float speed;
    public bool isRight;
    public LayerMask soldierSensor;
    PLayer m_player;
    public Vector3 right;
    public Vector3 left;
    public bool isDie;
    public Rigidbody2D rb;
    public float forceToDie;
    public Animator anim;
    public GameObject explosionPref;

    private void Awake()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Start()
    {
        isDie = false;
    }

    void PalyerDir()
    {
        m_player = FindObjectOfType<PLayer>();
        if (m_player.transform.position.x < transform.position.x)
        {
            isRight = false;
        }
        else
        {
            isRight = true;
        }
    }

    private void Update()
    {
        if (isDie)
        {
            return;
        }
        if (isRight)
        {
            transform.localScale = left;
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        else
        {
            transform.localScale = right;
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }

        if(Physics2D.OverlapCircle(transform.position, 0.05f, soldierSensor))
        {
            int choise = Random.Range(0, 3);
            if(choise == 0)
            {
                print("jump");
            }
            else
            {
                isRight = !isRight;
            }
        }
    }

    public void Die()
    {
        isDie = true;
        anim.SetTrigger("Die");
        rb.AddForce(Vector3.up * forceToDie, ForceMode2D.Impulse);
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject effect = Instantiate(explosionPref, transform.position + new Vector3(0,0.15f,0), Quaternion.identity);
        effect.GetComponent<EliminateExplosion>().Call();
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.05f);
    }
}
