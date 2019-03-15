﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    public float xMax;
    [SerializeField]
    public float yMax;
    [SerializeField]
    public float xMin;
    [SerializeField]
    public float yMin;
    public Transform target;


	// Use this for initialization
	void Start () {
        //Following it
        target = GameObject.Find("Ninja").transform;

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Finding characters postions
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

		
	}
}
