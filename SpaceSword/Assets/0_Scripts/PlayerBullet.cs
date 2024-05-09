using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float m_Speed = 75f,
        m_LifeTime = 5f,
        m_BulletDamage = 5f;

    void Start()
    {
        Destroy(gameObject, m_LifeTime);
    }

    void Update()
    {
        float moveZ = m_Speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(0, 0f, moveZ);

        transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyLife>().TakeDamage(m_BulletDamage);
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().LoadUlt();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TankShield"))
        {
            collision.gameObject.GetComponent<EnemyTank>().TakeDamage(m_BulletDamage);
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().LoadUlt();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
