using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform m_player;
    public Vector3 m_gizmoForward;
    public Vector3 m_gizmoBackWard;
    public float m_radius;
    public float m_offsetFw;
    public float m_offsetBw;

    private void Update()
    {
        m_gizmoForward.x = transform.position.x + m_offsetFw;
        m_gizmoForward.y = m_player.transform.position.y;
        m_gizmoForward.z = m_player.transform.position.z;

        m_gizmoBackWard.x = transform.position.x + m_offsetBw;
        m_gizmoBackWard.y = m_player.transform.position.y;
        m_gizmoBackWard.z = m_player.transform.position.z;

        if (m_player.transform.position.x < m_gizmoBackWard.x)
        {
            m_player.GetComponent<PLayer>().canMoveLeft = false;
        }
        else
        {
            m_player.GetComponent<PLayer>().canMoveLeft = true;
        }
    }

    private void LateUpdate()
    {
        if(m_player.transform.position.x > m_gizmoForward.x)
        {
            transform.position = new Vector3(m_player.position.x - m_offsetFw, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(m_gizmoForward, m_radius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(m_gizmoBackWard, m_radius);
    }
}
