using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{
    public Animator ModelAnim, PlayerAnim;
    public PlayerController PC;
    public EnemySpawner ES;
    // Start is called before the first frame update
    void Start()
    {
        ModelAnim = GetComponent<Animator>();
        PlayerAnim = transform.parent.GetComponent<Animator>();
        PC = GetComponentInParent<PlayerController>();
        ES = GameObject.FindWithTag("GameController").transform.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IntroAnimEnd()
    {
        PlayerAnim.enabled = true;
        PC.enabled = true;
        ES.enabled = true;
        ModelAnim.enabled = false;
    }
}
