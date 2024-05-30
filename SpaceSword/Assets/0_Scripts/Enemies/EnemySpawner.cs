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
                //SpawnFoe();

                /*GameObject Enemy = EnemyTypes[0];
                switch (Enemies[m_EnemyIndex].EnemyType)
                {
                    case EnemyStats.EnemyTypes.Fast:
                        {
                            Enemy = EnemyTypes[0];
                            break;
                        }

                    case EnemyStats.EnemyTypes.Medium:
                        {
                            Enemy = EnemyTypes[1];
                            break;
                        }
                    case EnemyStats.EnemyTypes.Tank:
                        {
                            Enemy = EnemyTypes[2];
                            break;
                        }
                    case EnemyStats.EnemyTypes.Lock:
                        {
                            Enemy = EnemyTypes[3];
                            break;
                        }
                    default:
                        {
                            Enemy = EnemyTypes[3];
                            break;
                        }
                }*/

                //GameObject SpawnedEnemy = Instantiate(Enemy, new Vector3(Random.Range(-9f, 9f), 0f, transform.position.z), transform.rotation);
                Enemies[m_EnemyIndex].m_Enemy.SetActive(true);
                Enemies[m_EnemyIndex].Spawned = true;
                Enemies[m_EnemyIndex].m_Enemy.GetComponent<EnemyLife>().Route = Enemies[m_EnemyIndex].RoutePos;

                m_EnemyIndex++;

                if (m_EnemyIndex < Enemies.Count)
                {
                    m_EnemySpawnTimer = Enemies[m_EnemyIndex].Delay;
                }
            }
            else if (AreActiveEnemiesPresent())
            {
                SpaceArrow.SetActive(true);
            }
        }


        ScoreText.text = Score + "";
    }
    bool AreActiveEnemiesPresent()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                return false; // Hay al menos un enemigo activo
            }
        }
        return true; // No hay enemigos activos
    }
    /*void SpawnFoe()
    {
        GameObject Enemy;
        float EnemyChance = Random.Range(0f, 100f);
        if (EnemyChance <= 40f) Enemy = EnemyTypes[0].gameObject;
        else if (EnemyChance <= 70f && EnemyChance > 40f) Enemy = EnemyTypes[1].gameObject;
        else if (EnemyChance <= 90f && EnemyChance > 70f) Enemy = EnemyTypes[2].gameObject;
        else Enemy = EnemyTypes[3].gameObject;  

        Instantiate(Enemy, new Vector3(Random.Range(-9f, 9f), 0f, transform.position.z), transform.rotation);
    }*/
    public void GetScore()
    {
        Score++;
    }

    [System.Serializable]
    public class EnemyStats
    {
        //public enum EnemyTypes { Fast, Medium, Tank, Lock }
        //[SerializeField] public EnemyTypes EnemyType;
        public GameObject m_Enemy;
        public bool Spawned = false;
        public float Delay;
        //public Transform m_SpawnPos;
        public List<Transform> Route = new List<Transform>();
        [HideInInspector] public List<Vector3> RoutePos = new List<Vector3>();
    }
}
