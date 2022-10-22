using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float m_speed = 0.2f;
    public int m_damage = 10;

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
