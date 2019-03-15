using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {

    public restartGame theGameManager;
    public Text YouWinScreen;
    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Trigger you win screen, and restart game

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Animator YouWin2 = YouWinScreen.GetComponent<Animator>();
            YouWin2.SetTrigger("GameWin");
            theGameManager.restartTheGame();
        }
    }

    //Destroy collected coin and restart game

    public void winGame()
    {
        Destroy(gameObject);
        theGameManager.restartTheGame();
        

    }
}
