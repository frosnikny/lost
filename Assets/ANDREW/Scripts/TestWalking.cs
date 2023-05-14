using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TestWalking : MonoBehaviour
{
    public float speed;
    private Transform player;

    public Rigidbody2D rb;
    public Animator anim;
    
    float attackTime;
    
    [SerializeField]private AudioClip swordSound;

    public int health;
    public GameObject coin;

    [SerializeField] public TopDownController user;

    void Start()
    {
        user.enemysNumber += 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0f, 0f);
        anim.SetFloat("DirectionLeft",0);
        anim.SetFloat("DirectionRight",0);
        anim.SetFloat("DirectionUp",0);
        anim.SetFloat("DirectionDown",0);
        anim.SetFloat("DirectionLeftUp",0);
        anim.SetFloat("DirectionLeftDown",0);
        anim.SetFloat("DirectionRightUp",0);
        anim.SetFloat("DirectionRightDown",0);
        
        checkPosition();
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            user.enemysNumber -= 1;
            // Debug.Log("Hello:" + user.enemysNumber.ToString());
            user.checkEnemys();
            Instantiate(coin, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }
    void checkPosition()
    {
        if (player!=null && Time.time - attackTime >= 1.267f)
        {
            anim.SetBool("AnimEnd",false);
            anim.SetBool("Attack",false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (player.position.x < transform.position.x && Math.Abs(player.position.y - transform.position.y) < 1)
            {
                anim.SetFloat("DirectionLeft", 1);
            }
            else if (player.position.x > transform.position.x && Math.Abs(player.position.y - transform.position.y) < 1)
            {
                anim.SetFloat("DirectionRight", 1);
            }
            else if (player.position.y > transform.position.y && Math.Abs(player.position.x - transform.position.x) < 1)
            {
                anim.SetFloat("DirectionUp", 1);
            }
            else if (player.position.y < transform.position.y && Math.Abs(player.position.x - transform.position.x) < 1)
            {
                anim.SetFloat("DirectionDown", 1);
            }
            else if (player.position.x < transform.position.x && player.position.y > transform.position.y)
            {
                anim.SetFloat("DirectionLeftUp", 1);
            }
            else if (player.position.x < transform.position.x && player.position.y < transform.position.y)
            {
                anim.SetFloat("DirectionLeftDown", 1);
            }
            else if (player.position.x > transform.position.y && player.position.y > transform.position.y)
            {
                anim.SetFloat("DirectionRightUp", 1);
            }
            else if (player.position.x > transform.position.x && player.position.y < transform.position.y)
            {
                anim.SetFloat("DirectionRightDown", 1);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            attackTime = Time.time;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            attackTime = Time.time;
        }
    }

    public void onAnimEnd()
    {
        SoundManager.instanse.PlaySound(swordSound);
        anim.SetBool("AnimEnd",true);
    }
    void OnCollisionExit2D(Collision2D other)
    {
        anim.SetBool("Attack", false);
        attackTime = 0;
    }
}
