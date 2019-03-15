using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState
{
    private Enemy enemy;
    private float attackTimer;
    private float attackCooldown = 3;
    private bool canAttack = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

    }

    //Attack if enemy is in melee range
    public void Execute()
    {
        Attack();
        if (enemy.InMeleeRange)
        {
            enemy.changeState(new MeleeState());
        }

        else if (enemy.Target != null)
        {

            enemy.move();
        }
        else
        {
            enemy.changeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    //Attacking animation
    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack)
        {
            canAttack = false;
            enemy.Anime.SetTrigger("attack");
        }
    }
}
