using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{


    public Animator Anime;
    public float maxSpeed;
    protected bool facingRight;
    public bool attack;
    [SerializeField]
    public int health;
    public abstract bool IsDead { get; }
    [SerializeField]
    private EdgeCollider2D SwordCollider;
    [SerializeField]
    private List<string> damageSources;



    // Use this for initialization
    public virtual void Start()
    {

        Anime = GetComponent<Animator>();
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract IEnumerator TakeDamage();

    //Changing direction
    public void ChangeDirection()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    //When attacking sword collider is enabled
    public void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;


    }
    //Taking damage
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(damageSources.Contains(other.tag))
            {
            StartCoroutine(TakeDamage());
        }
    }
   
}
 