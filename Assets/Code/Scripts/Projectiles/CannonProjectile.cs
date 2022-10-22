using UnityEngine;
using System.Collections;
using System;

public class CannonProjectile : ProjectileBase
{
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
}
