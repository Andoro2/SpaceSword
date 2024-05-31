using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject m_InGameUI, m_PauseMenu, m_EndGameMenu;
    PlayerController PC;
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
        PC.enabled = false;
    }
    public void Muelto()
    {
        m_InGameUI.SetActive(false);
        m_EndGameMenu.SetActive(true);
        m_EndGameMenu.transform.Find("ResultText").GetComponent<TextMeshProUGUI>().text = "Defated";
        PC.enabled = false;
    }
}
