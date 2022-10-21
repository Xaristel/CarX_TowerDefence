using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private GameObject m_moveTarget;

    [SerializeField]
    private int m_maxHP = 30;
    public int m_currentHP;

    public float m_speed = 0.1f;
    public Vector3 m_direction;
    public Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_moveTarget = GameObject.FindGameObjectWithTag("Castle");
        m_currentHP = m_maxHP;
        m_direction = m_moveTarget.transform.position - transform.position;
        m_rigidbody.velocity = m_direction.normalized * m_speed;
    }

    void Update()
    {
        if (m_moveTarget == null)
            return;

        //m_direction = m_moveTarget.transform.position - transform.position;
        //if (m_direction.magnitude > m_speed)
        //{
        //    m_direction = m_direction.normalized * m_speed;
        //}
        //transform.Translate(m_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Castle")
        {
            other.gameObject.GetComponent<Castle>().m_currentHP -= 1;

            Destroy(gameObject);
            return;
        }
    }
}
