using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public GameObject m_InGameUI, m_PauseMenu, m_EndGameMenu;
    PlayerController PC;
    public bool m_PerfectLevel = true;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindWithTag("Player").gameObject.transform.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.m_CurrentLife <= 0)
        {
            Muelto();
        }
    }
    public void LevelPassed()
    {
        m_InGameUI.SetActive(false);
        m_EndGameMenu.SetActive(true);
        m_EndGameMenu.transform.Find("ResultText").GetComponent<TextMeshProUGUI>().text = "Cleared";
        m_EndGameMenu.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "" + GetComponent<EnemySpawner>().Score;
        PC.enabled = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().StopShooting();
    }
    public void Muelto()
    {
        m_InGameUI.SetActive(false);
        m_EndGameMenu.SetActive(true);
        m_EndGameMenu.transform.Find("ResultText").GetComponent<TextMeshProUGUI>().text = "Defated";
        m_EndGameMenu.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "" + GetComponent<EnemySpawner>().Score;

        if (m_PerfectLevel) m_EndGameMenu.transform.Find("PerfectText").gameObject.SetActive(true);
        else m_EndGameMenu.transform.Find("PerfectText").gameObject.SetActive(false);

        PC.enabled = false;
    }
    public void UnPerfect()
    {
        m_PerfectLevel = false;
    }
}
