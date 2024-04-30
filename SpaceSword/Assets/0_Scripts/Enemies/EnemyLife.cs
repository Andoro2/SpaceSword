using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float m_EnemyLife = 50f,
        m_ExperienceValue = 75f,
        m_CollisionDamage = 20f,
        m_Speed = 15f;

    void Update()
    {
        transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
        if (m_EnemyLife <= 0f)
        {
            Death();
        }
    }
    public void TakeDamage(float Damage)
    {
        m_EnemyLife -= Damage;
    }
    void Death()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().AddExperience(m_ExperienceValue);
        GameObject.FindWithTag("GameController").GetComponent<EnemySpawner>().GetScore();
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(m_CollisionDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
