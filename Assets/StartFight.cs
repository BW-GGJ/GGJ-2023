using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    bool fightStarted, talking;
    [SerializeField] GameObject player;
    [SerializeField] KettuBossAI Ai;
    void Update()
    {
        if (KetuEncounterController.isFinished && !fightStarted && talking) 
        {
            fightStarted = true;
            Ai.SetFollowTarget(player);
            if (AudioManager.instance) AudioManager.instance.PlayBoss();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        talking = true;
        CampfireHUD.instance.OverrideText("Survive.");
    }
}
