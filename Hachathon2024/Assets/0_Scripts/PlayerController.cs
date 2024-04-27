using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public int m_PlayerLevel = 1;
    public float m_Speed = 5f,
        xLimit = 9f, zLimitMin = 0f, zLimitMax = 12.5f,
        m_ShootingRate = 0.25f;

    public GameObject m_Bullet, m_BulletHolder;
    private GameObject m_ShootPoints, Bullet;

    void Start()
    {
        m_ShootPoints = transform.Find("ShootPoints").gameObject;
        InvokeRepeating("Shoot", 0, m_ShootingRate);
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float moveX = horizontalInput * m_Speed * Time.deltaTime;
        float moveZ = verticalInput * m_Speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(moveX, 0f, moveZ);

        newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);
        newPosition.z = Mathf.Clamp(newPosition.z, zLimitMin, zLimitMax);

        transform.position = newPosition;
    }
    public void Shoot()
    {
        switch(m_PlayerLevel)
        {
            case 1:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleSingle").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
            case 2:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleLeft").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleRight").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
            case 3:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleSingle").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
            case 4:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleLeft").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleRight").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
            case 5:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleSingle").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftTwo").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightTwo").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
            case 6:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleLeft").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleRight").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftTwo").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightTwo").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                break;
        }
    }
}
