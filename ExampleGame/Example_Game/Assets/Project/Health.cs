using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public GameObject visualHealth;
    [Range(0f, 100f)]
    public float m_health;

    private void Start()
    {
        m_health = 100f;
    }

    private void Update()
    {
        visualHealth.transform.localScale = new Vector2((m_health * 1) / 100, 0.08f);
        visualHealth.GetComponent<SpriteRenderer>().color = Color.Lerp( Color.red, Color.green, (m_health * 1) / 100);
    }
}
