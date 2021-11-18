using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpin : MonoBehaviour
{
    Animator thisAnimator;
    GameManager gameManager;
    public int cooldown;
    float cooldownElapse;
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        cooldownElapse = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            cooldownElapse += Time.deltaTime;
        }
        if (cooldownElapse >= cooldown)
        {
            cooldownElapse = 0;
            thisAnimator.SetInteger("AnimationID", Random.Range(1,4));
            thisAnimator.SetTrigger("playTrigger");
        }




    }
}
