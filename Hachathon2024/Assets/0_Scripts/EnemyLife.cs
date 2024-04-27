using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float m_EnemyLife = 50f;
    void Start()
    {

    }

    void Update()
    {
        if (m_EnemyLife <= 0f)
        {
            Death();
        }
    }
    public void TakeDamage(float Damage)
    {
        m_EnemyLife -= Damage;
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
