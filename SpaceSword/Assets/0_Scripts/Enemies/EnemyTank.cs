using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float m_ShieldMaxLife,
        m_ShieldLife,
        m_ShieldRecoveryValue;
    void Start()
    {
        m_ShieldLife = m_ShieldMaxLife;
        transform.parent.parent.GetComponent<BoxCollider>().enabled = false;
        InvokeRepeating("ShieldRecovery", 0, 1f);
    }
    void ShieldRecovery()
    {
        if(m_ShieldLife + m_ShieldRecoveryValue > m_ShieldMaxLife)
        {
            m_ShieldLife = m_ShieldMaxLife;
        }
        else
        {
            m_ShieldLife += m_ShieldRecoveryValue;
        }
    }
    public void TakeDamage(float Dmg)
    {
        m_ShieldLife -= Dmg;

        if (m_ShieldLife <= 0f)
        {
            transform.parent.parent.GetComponent<BoxCollider>().enabled = true;
            Destroy(gameObject);
        }
    }
}
