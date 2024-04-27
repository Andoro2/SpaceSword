using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float m_EnemyLife = 50f,
        m_ExperienceValue = 75f;

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
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().AddExperience(m_ExperienceValue);
        Destroy(gameObject);
    }
}
