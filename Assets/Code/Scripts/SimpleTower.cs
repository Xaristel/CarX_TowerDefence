using UnityEngine;
using System.Collections;

public class SimpleTower : MonoBehaviour
{
    [SerializeField]
    private float m_shootInterval = 0.5f;

    [SerializeField]
    private float m_range = 4f;

    [SerializeField]
    private GameObject m_projectilePrefab;

    private float m_lastShotTime = 0f;

    void Update()
    {
        if (m_projectilePrefab == null)
            return;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) > m_range)
                continue;

            if (m_lastShotTime + m_shootInterval > Time.time)
                continue;

            // shot
            var projectile = Instantiate(m_projectilePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            var projectileBeh = projectile.GetComponent<GuidedProjectile>();
            projectileBeh.m_target = enemy.gameObject;

            m_lastShotTime = Time.time;
        }
    }
}
