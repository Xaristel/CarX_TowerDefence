using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField]
    private int m_maxHP = 20;

    public int m_currentHP;

    void Start()
    {
        m_currentHP = m_maxHP;
    }

    void Update()
    {
        if (m_currentHP <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
