using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour
{
    public float ShootRate = 0.5f;
    public GameObject Bullet;
    private GameObject LeftShootPoint, RightShootPoint;
    void Start()
    {
        LeftShootPoint = transform.Find("ShootPoints").transform.Find("LeftShooter").transform.gameObject;
        RightShootPoint = transform.Find("ShootPoints").transform.Find("RightShooter").transform.gameObject;

        InvokeRepeating("Shoot", 0, ShootRate);
    }

    public void Shoot()
    {
        Instantiate(Bullet, LeftShootPoint.transform.position, LeftShootPoint.transform.rotation);
        Instantiate(Bullet, RightShootPoint.transform.position, RightShootPoint.transform.rotation);
    }
}
