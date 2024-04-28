using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public int m_PlayerLevel = 1;

    public float flipSpeed, m_CurrentLife, m_MaxLife = 500f, m_CurrentExp;

    public float m_Speed = 5f,
        xLimit = 9f, zLimitMin = 0f, zLimitMax = 12.5f,
        m_ShootingRate = 0.25f;

    public GameObject m_Bullet, m_BulletHolder;
    private GameObject m_ShootPoints, Bullet,
        FrontCenter, FrontDouble, Lateral1, Lateral2;

    private Vector3 velocity = Vector3.zero;

    private Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        m_ShootPoints = transform.Find("ShootPoints").gameObject;
        GameObject Model = transform.Find("Model").gameObject;
        FrontCenter = Model.transform.Find("FrontCenter").gameObject;
        FrontDouble = Model.transform.Find("FrontDouble").gameObject;
        Lateral1 = Model.transform.Find("Lateral1").gameObject;
        Lateral2 = Model.transform.Find("Lateral2").gameObject;

        InvokeRepeating("Shoot", 0, m_ShootingRate);

        m_CurrentLife = m_MaxLife;
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

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 0.3f);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            BarrelRoll();
            StartCoroutine("IFrames");
        }
    }
    IEnumerator IFrames()
    {
        GetComponent<Collider>().enabled = false;  
        yield return new WaitForSeconds(1.25f);
        GetComponent<Collider>().enabled = true;
    }
    public void BarrelRoll()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            Anim.SetTrigger("RightRoll");
        }
        else
        {
            Anim.SetTrigger("LeftRoll");
        }
    }
    public void TakeDamage(float Dmg)
    {
        m_CurrentLife -= Dmg;
    }
    public void AddExperience(float Exp)
    {
        m_CurrentExp += Exp;
        if(m_CurrentExp >= 100)
        {
            LevelUp();
            m_CurrentExp = Exp - 100;
        }
    }
    public void LevelUp()
    {
        if (m_PlayerLevel < 6) m_PlayerLevel++;
    }
    public void Shoot()
    {
        switch(m_PlayerLevel)
        {
            case 1:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleSingle").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);

                FrontCenter.SetActive(true);
                FrontDouble.SetActive(false);
                Lateral1.SetActive(false);
                Lateral2.SetActive(false);
                break;
            case 2:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleLeft").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleRight").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);

                FrontCenter.SetActive(false);
                FrontDouble.SetActive(true);
                Lateral1.SetActive(false);
                Lateral2.SetActive(false);
                break;
            case 3:
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("MiddleSingle").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("LeftOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);
                Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find("RightOne").gameObject.transform.position, Quaternion.identity);
                Bullet.transform.SetParent(m_BulletHolder.transform);

                FrontCenter.SetActive(true);
                FrontDouble.SetActive(false);
                Lateral1.SetActive(true);
                Lateral2.SetActive(false);
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

                FrontCenter.SetActive(false);
                FrontDouble.SetActive(true);
                Lateral1.SetActive(true);
                Lateral2.SetActive(false);
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

                FrontCenter.SetActive(true);
                FrontDouble.SetActive(false);
                Lateral1.SetActive(true);
                Lateral2.SetActive(true);
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

                FrontCenter.SetActive(true);
                FrontDouble.SetActive(false);
                Lateral1.SetActive(true);
                Lateral2.SetActive(true);
                break;
        }
    }
}
