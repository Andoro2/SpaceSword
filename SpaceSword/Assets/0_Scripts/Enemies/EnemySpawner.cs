using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EnemySpawner : MonoBehaviour
{
    public float Score = 0;
    public TMP_Text ScoreText;
    public float m_EnemySpawnTime = 5f,
        m_EnemySpawnTimer;
    //public List<GameObject> EnemyTypes = new List<GameObject>();
    [SerializeField] 
    public List<EnemyStats> Enemies = new List<EnemyStats>();
    public int m_EnemyIndex = 0;
    public GameObject SpaceArrow;
    void Start()
    {
        //m_EnemySpawnTimer = m_EnemySpawnTime;
        foreach (EnemyStats EnemyStat in Enemies)
        {
            foreach (Transform EnemyTrans in EnemyStat.Route)
            {
                EnemyStat.RoutePos.Add(EnemyTrans.position);

            }
        }

        m_EnemySpawnTimer = Enemies[m_EnemyIndex].Delay;
    }
    void Update()
    {
        if(m_EnemySpawnTimer >= 0) m_EnemySpawnTimer -= Time.deltaTime;

        if (m_EnemySpawnTimer < 0)
        {
            if (m_EnemyIndex < Enemies.Count)
            {
                Enemies[m_EnemyIndex].m_Enemy.SetActive(true);
                Enemies[m_EnemyIndex].Spawned = true;
                Enemies[m_EnemyIndex].m_Enemy.GetComponent<EnemyLife>().Route = Enemies[m_EnemyIndex].RoutePos;

                m_EnemyIndex++;

                if (m_EnemyIndex < Enemies.Count)
                {
                    m_EnemySpawnTimer = Enemies[m_EnemyIndex].Delay;
                }
            }
            else if (AreActiveEnemiesPresent() && SpaceArrow != null)
            {
                SpaceArrow.SetActive(true);
            }
        }


        ScoreText.text = Score + "";
    }
    bool AreActiveEnemiesPresent()
    {
        GameObject[] m_Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in m_Enemies)
        {
            if (enemy.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
    public void GetScore()
    {
        Score++;
    }

    [System.Serializable]
    public class EnemyStats
    {
        public GameObject m_Enemy;
        public bool Spawned = false;
        public float Delay;
        public List<Transform> Route = new List<Transform>();
        [HideInInspector] public List<Vector3> RoutePos = new List<Vector3>();
    }
}
