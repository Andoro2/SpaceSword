using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyLock : MonoBehaviour
{
    public float m_SideSpeed, m_SideLimit, m_ShootRate;
    public bool m_Side;
    public GameObject m_Bullet;
    private Transform m_Player;
    private GameObject m_Turret;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player").transform;
        m_Turret = transform.Find("ShootPoint").gameObject;
        InvokeRepeating("Shoot", 0f, m_ShootRate);
    }

    // Update is called once per frame
    void Update()
    {
        m_Turret.transform.LookAt(m_Player);

        if (m_Side)
        {
            transform.Translate(Vector3.left * m_SideSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * m_SideSpeed * Time.deltaTime);
        }

        if (transform.position.x >= m_SideLimit)
        {
            m_Side = true;
        }
        if (transform.position.x <= -m_SideLimit)
        {
            m_Side = false;
        }
    }
    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, m_Turret.transform.rotation);
    }
}
