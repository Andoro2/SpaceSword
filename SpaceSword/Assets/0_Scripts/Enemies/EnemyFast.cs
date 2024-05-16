using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : MonoBehaviour
{
    public float m_SideSpeed, xPosition, m_ShootRate;
    public GameObject m_Bullet;
    public bool m_Side = false;

    void Start()
    {
        xPosition = transform.position.x;
        //InvokeRepeating("Shoot", 0f, m_ShootRate);
    }
    void Update()
    {
        if(m_Side)
        {
            transform.Translate(Vector3.left * m_SideSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * m_SideSpeed * Time.deltaTime);
        }

        if(transform.position.x > xPosition + 2)
        {
            Shoot();
            m_Side = true;
        }
        if (transform.position.x < xPosition - 2)
        {
            Shoot();
            m_Side = false;
        }
    }
    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, transform.Find("ShootPoint").transform.rotation);
    }
}
