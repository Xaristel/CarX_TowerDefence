using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class CannonTower : MonoBehaviour
{
    public float m_shootInterval = 0.5f;
    public float m_range = 4f;
    public GameObject m_projectilePrefab;
    public Transform m_shootPoint;
    private float m_lastShotTime = -0.5f;
    public Enemy target;

    [SerializeField]
    private float m_speed = 8f;

    void Update()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            target = enemy;
            if (Vector3.Distance(transform.position, enemy.transform.position) > m_range)
                continue;

            if (m_lastShotTime + m_shootInterval > Time.time)
                continue;

            // shot
            Instantiate(m_projectilePrefab, m_shootPoint.position, m_shootPoint.rotation);
            m_lastShotTime = Time.time;
        }

        if (target == null)
            return;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * m_speed);
    }
}
