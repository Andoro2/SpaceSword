using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Slider m_LifeSlider, m_ExpSlider;

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

        m_LifeSlider.value = (float)m_CurrentLife / m_MaxLife;
        m_ExpSlider.value = (float)m_CurrentExp / 100f;
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
        switch (m_PlayerLevel)
        {
            case 1:
                ShootBullet("MiddleSingle");
                SetActiveObjects(true, false, false, false);
                break;
            case 2:
                ShootBullet("MiddleLeft");
                ShootBullet("MiddleRight");
                SetActiveObjects(false, true, false, false);
                break;
            case 3:
                ShootBullet("MiddleSingle");
                ShootBullet("LeftTwo");
                ShootBullet("RightTwo");
                SetActiveObjects(true, false, true, false);
                break;
            case 4:
                ShootBullet("MiddleLeft");
                ShootBullet("MiddleRight");
                ShootBullet("LeftTwo");
                ShootBullet("RightTwo");
                SetActiveObjects(false, true, true, false);
                break;
            case 5:
                ShootBullet("MiddleSingle");
                ShootBullet("LeftOne");
                ShootBullet("RightOne");
                ShootBullet("LeftTwo");
                ShootBullet("RightTwo");
                SetActiveObjects(true, false, true, true);
                break;
            case 6:
                ShootBullet("MiddleLeft");
                ShootBullet("MiddleRight");
                ShootBullet("LeftOne");
                ShootBullet("RightOne");
                ShootBullet("LeftTwo");
                ShootBullet("RightTwo");
                SetActiveObjects(true, true, true, true);
                break;
            default:
                SetActiveObjects(true, false, false, false);
                break;
        }
    }

    private void ShootBullet(string bulletPoint)
    {
        Bullet = Instantiate(m_Bullet, m_ShootPoints.transform.Find(bulletPoint).gameObject.transform.position, Quaternion.identity);
        Bullet.transform.SetParent(m_BulletHolder.transform);
    }

    private void SetActiveObjects(bool frontCenter, bool frontDouble, bool lateral1, bool lateral2)
    {
        FrontCenter.SetActive(frontCenter);
        FrontDouble.SetActive(frontDouble);
        Lateral1.SetActive(lateral1);
        Lateral2.SetActive(lateral2);
    }
}
