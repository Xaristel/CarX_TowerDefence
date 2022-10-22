using UnityEngine;
using System.Collections;

public class Enemy : EnemyBase
{
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_moveTarget = GameObject.FindGameObjectWithTag("Castle");
        m_currentHP = m_maxHP;
        m_direction = m_moveTarget.transform.position - transform.position;
        m_rigidbody.velocity = m_direction.normalized * m_speed;
    }

    void Update()
    {
        if (m_moveTarget == null)
            return;
    }
}
