using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApplication : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //If espace  button is presed, application will close
        if (Input.GetKey("escape")) Application.Quit();
		
	}

    public void QuitGame()
    {

        Application.Quit();
    }
}
