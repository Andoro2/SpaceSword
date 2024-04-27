using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : MonoBehaviour
{
    public float m_ShootRate;
    public GameObject m_Bullet;
    void Start()
    {
        InvokeRepeating("Shoot", 0f, m_ShootRate);
    }
    void Update()
    {
        
    }
    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, Quaternion.identity);
    }
}
