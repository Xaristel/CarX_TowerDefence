using UnityEngine;
using System.Collections;
using System;

public class CannonProjectile : MonoBehaviour
{
    public float m_speed = 0.3f;
    public int m_damage = 10;

    void Update()
    {
        var translation = Vector3.forward * m_speed;
        transform.Translate(translation);
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
