using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool m_Enemy = false, m_LevelBoss = false;

    [HideInInspector] public bool m_Muelto = false;

    void Update()
    {
        if(Route.Count > 0 && RouteIndex <= Route.Count && !m_Muelto)
        {
            transform.position = Vector3.MoveTowards(transform.position, Route[RouteIndex], m_Speed * Time.deltaTime);

            transform.LookAt(Route[RouteIndex]);

            if (Vector3.Distance(transform.position, Route[RouteIndex]) <= 0.25f) RouteIndex++;
        }

        if (m_EnemyLife <= 0f && !m_Muelto) Death();
    }
    public void TakeDamage(float Damage)
    {
        if(transform.name == "SpaceArrow")
        {
            m_EnemyLife -= Damage;
            Instantiate(m_ImpactVFX, transform.position, Quaternion.identity);
        }
        else if(transform.Find("Body").Find("Shield") == null)
        {
            m_EnemyLife -= Damage;
            Instantiate(m_ImpactVFX, transform.position, Quaternion.identity);
        }
        else if (transform.Find("Body").Find("Shield").GetComponent<EnemyTankShield>().m_ShieldLife > 0)
        {
            transform.Find("Body").Find("Shield").GetComponent<EnemyTankShield>().TakeDamage(Damage);
        }
    }
    void Death()
    {
        m_Muelto = true;

        GetComponent<BoxCollider>().enabled = false;    

        GameObject.FindWithTag("Player").GetComponent<PlayerController>().AddExperience(m_ExperienceValue);
        GameObject.FindWithTag("GameController").GetComponent<EnemySpawner>().GetScore();

        if (m_LevelBoss) GameObject.FindWithTag("GameController").GetComponent<GameController>().LevelPassed();

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        StartCoroutine("DeathExplosions");

        //Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (m_Enemy) collision.gameObject.GetComponent<PlayerController>().TakeDamage(m_CollisionDamage);
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().UnPerfect();

            Destroy(gameObject);
        }
    }

    public float m_ExplosionAmount, m_ExplosionRate;
    public GameObject m_ExplosionVFX;
    public AudioClip m_ExplosionSFX1, m_ExplosionSFX2;

    IEnumerator DeathExplosions()
    {
        for (int i = 0; i < m_ExplosionAmount; i++)
        {
            Vector3 explosionSpawnPos = new Vector3(
                Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f),
                Random.Range(transform.position.y - 0.5f, transform.position.y + 0.5f),
                Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f));

            GameObject spawnedPrefab = Instantiate(m_ExplosionVFX, explosionSpawnPos, Quaternion.identity);

            spawnedPrefab.transform.AddComponent<AudioSource>();
            if (Random.Range(0, 1) == 0) spawnedPrefab.GetComponent<AudioSource>().clip = m_ExplosionSFX1;
            else spawnedPrefab.GetComponent<AudioSource>().clip = m_ExplosionSFX2;

            spawnedPrefab.GetComponent<AudioSource>().loop = false;
            spawnedPrefab.GetComponent<AudioSource>().Play();
            
            spawnedPrefab.SetActive(true);

            yield return new WaitForSeconds(m_ExplosionRate);
        }

        Destroy(gameObject);
    }
}
