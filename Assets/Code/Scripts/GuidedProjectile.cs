using UnityEngine;
using System.Collections;

public class GuidedProjectile : MonoBehaviour
{
    public GameObject m_target;

    [SerializeField]
    private float m_speed = 0.2f;

    [SerializeField]
    private int m_damage = 10;

    void Update()
    {
        if (m_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var translation = m_target.transform.position - transform.position;
        if (translation.magnitude > m_speed)
        {
            translation = translation.normalized * m_speed;
        }
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
