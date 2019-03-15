using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;
    private float patrolTimer;
    private float patrolDuration=10;


    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    //Go in patroll
    public void Execute()
    {
        Debug.Log("Patroling");
        Patrol();
        enemy.move();

        //Go in attacking state
        if(enemy.Target != null && enemy.InMeleeRange)
        {
            enemy.changeState(new MeleeState());
        }
    }

    public void Exit()
    {
        
    }

    //When collide with edge, change direction
    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }


    private void Patrol()
    {

        //Go in idle state after some time
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {

            enemy.changeState(new IdleState());
        }
    }
}
