using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public float m_shootInterval;
    public float m_range;
    public float m_lastShotTime;

    public GameObject m_projectilePrefab;
    public Transform m_shootPoint;
    public Enemy m_currentTarget;

    public abstract void Shoot();

    public virtual Enemy FindTarget()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < m_range)
                return enemy;
        }

        return null;
    }

    public virtual bool CanShoot()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return false;

        if (m_currentTarget == null)
        {
            m_currentTarget = FindTarget();
        }

        if (m_currentTarget == null)
            return false;

        if (Vector3.Distance(transform.position, m_currentTarget.transform.position) > m_range)
        {
            m_currentTarget = null;
            return false;
        }

        return true;
    }
}
