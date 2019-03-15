using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinjaController : Character {

    //Movement variables
    
    Rigidbody2D RB;

    //Jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    private bool immortal = false;
    [SerializeField]
    private float immortalTime;
    public Slider healthSlider;
    public restartGame theGameManager;
 

    //Die when health are equal to 0

    public override bool IsDead
    {
        get
        {
           
            return health <= 0;
        }
    }


    // Use this for initialization
    public override void Start () {
    
        base.Start();
        RB = GetComponent<Rigidbody2D>();

        if (IsDead)
        {
            Die();
        }


    }

    // Update is called once per frame

    void Update()
    {
        if (!IsDead)
        {
            //Jumping
            if (grounded && Input.GetAxis("Jump") > 0)
            {
                grounded = false;
                Anime.SetBool("isGrounded", grounded);
                RB.AddForce(new Vector2(0, jumpHeight));
            }

            HandleInput();
        }
        
    }



    void FixedUpdate() {


        if (!IsDead)
        {

            //Ground speed
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Anime.SetBool("isGrounded", grounded);
            Anime.SetFloat("verticalSpeed", RB.velocity.y);


            //Movement
            float move = Input.GetAxis("Horizontal");
            Anime.SetFloat("Speed", Mathf.Abs(move));
            RB.velocity = new Vector2(move * maxSpeed, RB.velocity.y);

            //Facing left and right

            if (move > 0 && !facingRight || move < 0 && facingRight)
            {
                ChangeDirection();


            }

            HandleAttacks();
            attack = false;

        }
       
        
	}


    
        //Attack animation when attacking
        public void HandleAttacks()
        {

            if (attack)
            {

                Anime.SetTrigger("attack");
            }

        }

    //Keyboard button for attack
     public void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;

        }
    }

    //Destroy coin when collected
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag=="coin")
        {
            Destroy(other.gameObject);
            

        }

    }

    //Taking damage
    public override IEnumerator TakeDamage()
    {
        if (!immortal)
        {
            health -= 1;
            if (!IsDead)
            {
                Anime.SetTrigger("Damage");
                immortal = true;

                yield return new WaitForSeconds(immortalTime);

                immortal = false;



            }
            else
            {
                Anime.SetLayerWeight(1, 0);
                Anime.SetTrigger("Death");
                theGameManager.restartTheGame();
            }

        }
        
    }

    //Restart when u die
    void Die()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}
