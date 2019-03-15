using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{

    private Enemy enemy;
    private float idleTimer;
    private float idleDuration = 5;

    public void Enter(Enemy enemy)
    {
       this.enemy = enemy;
    }

    //Go in idle state
    public void Execute()
    {
        Debug.Log("I'm Idling");
        Idle();

        if (enemy.Target != null)
        {
            enemy.changeState(new PatrolState());

        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Idle()
    {
        //Idle animation
        enemy.Anime.SetFloat("Speed", 0);
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            //Change state to Patrol after some time
            enemy.changeState(new PatrolState());
        }
    }
}
