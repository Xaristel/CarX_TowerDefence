using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float m_spawnInterval = 2;

    private float m_lastSpawnTime = -7;

    [SerializeField]
    private GameObject m_enemy;

    void Update()
    {
        if (Time.time > m_lastSpawnTime + m_spawnInterval)
        {
            Instantiate(m_enemy, transform.position, Quaternion.identity);

            m_lastSpawnTime = Time.time;
        }
    }
}
