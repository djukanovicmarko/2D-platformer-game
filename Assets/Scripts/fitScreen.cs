using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitScreen : MonoBehaviour {

    //Camera main aspect, so it can fit screen on different resolutions

	// Use this for initialization
	void Start () {

        Camera.main.aspect = 16f / 9f;

	}
	
	// Update is called once per frame
	void Update(){

    }

	
}
