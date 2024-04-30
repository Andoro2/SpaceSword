using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator m_ShipModelAnim;
    public void NextScene()
    {
        m_ShipModelAnim.SetTrigger("StartGame");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OnEndStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
