using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

    [SerializeField]
    private Enemy enemy;
    //If it collides with tag Player, that is its enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;

        }
    }
    //When Player tag leave collision, enemy target is null, so it can go to patrolling and idlling
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = null;
        
        }
    }
}