using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public GameObject m_moveTarget;
    public int m_maxHP;
    public int m_currentHP;

    public float m_speed;
    public Vector3 m_direction;
    public Rigidbody m_rigidbody;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Castle")
        {
            other.gameObject.GetComponent<Castle>().m_currentHP -= 1;

            Destroy(gameObject);
            return;
        }
    }
}
