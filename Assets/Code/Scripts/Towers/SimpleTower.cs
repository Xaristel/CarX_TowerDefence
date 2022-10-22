using UnityEngine;
using System.Collections;

public class SimpleTower : TowerBase
{
    void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        if (m_lastShotTime + m_shootInterval > Time.time)
            return;

        var projectile = Instantiate(m_projectilePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        projectile.GetComponent<GuidedProjectile>().m_target = m_currentTarget.gameObject;

        m_lastShotTime = Time.time;
    }
}
