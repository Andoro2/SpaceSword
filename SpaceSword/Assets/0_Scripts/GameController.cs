using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject m_InGameUI, m_PauseMenu, m_DeathMenu;
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
    void Muelto()
    {
        m_InGameUI.SetActive(false);
        m_DeathMenu.SetActive(true);
        PC.enabled = false;
    }
}
