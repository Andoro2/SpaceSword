using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public float Score = 0;
    public TMP_Text ScoreText;
    public float m_EnemySpawnTime = 5f,
        m_EnemySpawnTimer;
    public List<GameObject> Enemies = new List<GameObject>();
    void Start()
    {
        m_EnemySpawnTimer = m_EnemySpawnTime;
    }
    void Update()
    {
        m_EnemySpawnTimer -= Time.deltaTime;

        if(m_EnemySpawnTimer < 0)
        {
            SpawnFoe();

            m_EnemySpawnTimer = m_EnemySpawnTime;
        }

        ScoreText.text = Score + "";
    }
    void SpawnFoe()
    {
        GameObject Enemy;
        float EnemyChance = Random.Range(0f, 100f);
        if (EnemyChance <= 40f) Enemy = Enemies[0].gameObject;
        else if (EnemyChance <= 80f && EnemyChance > 40f) Enemy = Enemies[1].gameObject;
        else Enemy = Enemies[2].gameObject;  

        Instantiate(Enemy, new Vector3(Random.Range(-9f, 9f), 0f, transform.position.z), transform.rotation);
    }
    public void GetScore()
    {
        Score++;
    }
}
