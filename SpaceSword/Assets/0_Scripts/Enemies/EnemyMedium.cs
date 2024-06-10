using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour
{
    public float ShootRate = 0.5f;
    public GameObject Bullet;
    private GameObject LeftShootPoint, RightShootPoint;

    public AudioClip m_MediumShotSFX;
    private AudioSource m_AudioSource;
    void Start()
    {
        LeftShootPoint = transform.Find("ShootPoints").transform.Find("LeftShooter").transform.gameObject;
        RightShootPoint = transform.Find("ShootPoints").transform.Find("RightShooter").transform.gameObject;

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_MediumShotSFX;

        InvokeRepeating("Shoot", 0, ShootRate);
    }

    public void Shoot()
    {
        Instantiate(Bullet, LeftShootPoint.transform.position, LeftShootPoint.transform.rotation);
        Instantiate(Bullet, RightShootPoint.transform.position, RightShootPoint.transform.rotation);
        m_AudioSource.Play();
    }
}
