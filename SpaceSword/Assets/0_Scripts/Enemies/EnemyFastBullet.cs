using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFastBullet : MonoBehaviour
{
    public float m_Speed = 75f,
        m_BulletDamage = 5f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(m_BulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
