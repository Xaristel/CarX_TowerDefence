using UnityEngine;
using System.Collections;
using System;

public class CannonProjectile : MonoBehaviour
{
    public float m_speed = 0.2f;
    public int m_damage = 10;
    public Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * m_speed;
    }

    private void Update()
    {
        if (transform.position.magnitude > 30)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
            return;

        enemy.m_currentHP -= m_damage;
        if (enemy.m_currentHP <= 0)
        {
            Destroy(enemy.gameObject);
        }
        Destroy(gameObject);
    }
}
