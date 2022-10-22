using UnityEngine;

public class GuidedProjectile : ProjectileBase
{
    public GameObject m_target;

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
}
