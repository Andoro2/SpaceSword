using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float m_LaserDPS = 10f;
    public Vector3 m_BoxSize;

    public float m_CheckInterval = 1f;

    void Start()
    {
        InvokeRepeating("CheckCollisions", 0, m_CheckInterval);
    }

    void CheckCollisions()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, m_BoxSize / 2f, Quaternion.identity);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyLife>().TakeDamage(m_LaserDPS);
            }
            if (col.gameObject.CompareTag("TankShield"))
            {
                col.gameObject.GetComponent<EnemyTankShield>().TakeDamage(m_LaserDPS);
                Debug.Log("impakto");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, m_BoxSize);
    }
}
