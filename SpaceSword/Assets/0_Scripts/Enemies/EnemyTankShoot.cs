using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShoot : MonoBehaviour
{
    public float m_ShootRate;
    public GameObject m_Bullet;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, m_ShootRate);
    }
    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, transform.Find("ShootPoint").transform.rotation);
    }
}
