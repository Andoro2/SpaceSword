using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShoot : MonoBehaviour
{
    public float m_ShootRate;
    public GameObject m_Bullet;

    public AudioClip m_TankShotSFX;
    private AudioSource m_AudioSource;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, m_ShootRate);

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_TankShotSFX;
    }
    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, transform.Find("ShootPoint").transform.rotation);
        m_AudioSource.Play();
    }
}
