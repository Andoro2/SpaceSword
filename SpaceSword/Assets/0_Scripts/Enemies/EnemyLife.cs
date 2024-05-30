using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float m_EnemyLife = 50f,
        m_ExperienceValue = 75f,
        m_CollisionDamage = 20f,
        m_Speed = 15f;

    public GameObject m_ImpactVFX;
    public int RouteIndex = 0;
    public List<Vector3> Route = new List<Vector3>();

    void Update()
    {
        //transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
        if(Route.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Route[RouteIndex], m_Speed * Time.deltaTime);

            transform.LookAt(Route[RouteIndex]);

            if (Vector3.Distance(transform.position, Route[RouteIndex]) <= 0.25f) RouteIndex++;
        }

        if (m_EnemyLife <= 0f) Death();
    }
    public void TakeDamage(float Damage)
    {
        m_EnemyLife -= Damage;
        Instantiate(m_ImpactVFX, transform.position, Quaternion.identity);
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
