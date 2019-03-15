using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    //HUD images
    public Sprite[] Hearts;
    public Image HeartUI;

    //Main character
    private NinjaController player;
    
    //Finding main character
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<NinjaController>();
    }
    //Health from top left corner
    void Update()
    {
        HeartUI.sprite = Hearts[player.health];
    }
}

