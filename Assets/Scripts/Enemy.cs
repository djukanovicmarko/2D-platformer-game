using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public IEnemyState currentState;
    public GameObject Target { get; set; }
    private float MeleeRange=0.3f;

    //Determing Melee range
    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= MeleeRange;
            }
            return false;
        }
    }
    //Enemy is dead if their healt drop to 0
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }




    // Use this for initialization
    public override void Start()
    {
        base.Start();
        changeState(new IdleState());
    }


    // Update is called once per frame
    void Update()
    {
        
        if (!IsDead)
        {

            currentState.Execute();
            LookAtTarget();
        }
            
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }


        }
    }

    public void changeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();

        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void move()
    {
        Anime.SetFloat("Speed", 1);
        transform.Translate(GetDirecton() * (maxSpeed * Time.deltaTime));

    }
    public Vector2 GetDirecton()
    {
        return facingRight ? Vector2.right : Vector2.left;
           
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);

    }

    public override IEnumerator TakeDamage()
    {
        health -= 10;

        if (!IsDead)
        {
            Anime.SetTrigger("Damage");
        }
        else
        {
            Anime.SetTrigger("Death");
            yield return null;
        }
    }

}
