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

    private void Start()
    {

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.05f);
    }
}
