using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class CannonTower : MonoBehaviour
{
    public float m_shootInterval = 0.5f;
    public float m_range = 2f;
    public GameObject m_projectilePrefab;
    public Transform m_shootPoint;
    private float m_lastShotTime = -0.5f;
    private Enemy m_currentTarget;

    [SerializeField]
    private float m_speed = 5f;

    void Update()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return;

        if (m_currentTarget == null)
        {
            m_currentTarget = FindTarget();
        }

        if (m_currentTarget == null)
            return;

        if (Vector3.Distance(transform.position, m_currentTarget.transform.position) > m_range)
        {
            m_currentTarget = null;
            return;
        }

        var enemyVelocity = m_currentTarget.GetComponent<Enemy>().m_rigidbody.velocity;
        var projSpeed = m_projectilePrefab.GetComponent<CannonProjectile>().m_speed;
        Quaternion rotation = transform.rotation;

        if (InterceptionDirection(m_currentTarget.transform.position, m_shootPoint.position, enemyVelocity, projSpeed, out Vector3 predictiveDirection))
        {
            rotation = Quaternion.LookRotation(predictiveDirection);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * m_speed);

        //shot
        if (m_lastShotTime + m_shootInterval > Time.time)
            return;

        Instantiate(m_projectilePrefab, m_shootPoint.position, m_shootPoint.rotation);
        m_lastShotTime = Time.time;
    }

    private Enemy FindTarget()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < m_range)
                return enemy;
        }

        return null;
    }

    private bool InterceptionDirection(Vector3 enemyPos, Vector3 projPos, Vector3 enemyVelocity, float projSpeed, out Vector3 predictiveDirection)
    {
        var lastDirection = projPos - enemyPos;
        var lastDirectionLength = lastDirection.magnitude;
        var alpha = Vector3.Angle(lastDirection, enemyVelocity) * Mathf.Deg2Rad;
        var enemySpeed = enemyVelocity.magnitude;
        float r = enemySpeed / projSpeed;

        if (SolveQuadraticEquation(1 - r * r, 2f * r * lastDirectionLength * Mathf.Cos(alpha), -(lastDirectionLength * lastDirectionLength),
            out float root1, out float root2) == 0)
        {
            predictiveDirection = Vector3.zero;
            return false;
        }

        var predictiveDirectionLength = Mathf.Max(root1, root2);
        var t = predictiveDirectionLength / projSpeed;
        predictiveDirection = (enemyPos + enemyVelocity * t) - projPos;
        return true;
    }

    private int SolveQuadraticEquation(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4f * a * c;

        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -Mathf.Infinity;
            return 0;
        }

        root1 = (-b + Mathf.Sqrt(discriminant)) / 2f * a;
        root2 = (-b - Mathf.Sqrt(discriminant)) / 2f * a;

        if (discriminant > 0)
            return 2;
        else
            return 1;
    }
}
