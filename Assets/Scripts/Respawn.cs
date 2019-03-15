using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public restartGame theGameManager;

    //On collision with the right coin that ends game, or if u drop from the map, player will hit colliders that will restart game
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            theGameManager.restartTheGame();
        }
    }
}
