using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private GameObject m_moveTarget;

    [SerializeField]
    private float m_speed = 0.1f;

    [SerializeField]
    private int m_maxHP = 30;

    public int m_currentHP;

    void Start()
    {
        m_moveTarget = GameObject.FindGameObjectWithTag("Castle");
        m_currentHP = m_maxHP;
    }

    void Update()
    {
        if (m_moveTarget == null)
            return;

        var translation = m_moveTarget.transform.position - transform.position;
        if (translation.magnitude > m_speed)
        {
            translation = translation.normalized * m_speed;
        }
        transform.Translate(translation);
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
