using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float m_ShieldMaxLife,
        m_ShieldLife,
        m_ShieldRecoveryValue;
    // Start is called before the first frame update
    void Start()
    {
        m_ShieldLife = m_ShieldMaxLife;
        InvokeRepeating("ShieldRecovery", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if(m_ShieldLife <= 0f) Destroy(gameObject);
    }
}
