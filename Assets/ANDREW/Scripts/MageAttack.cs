using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour
{
    public GameObject mageBolt;
    public Transform shotPoint;
    public SpriteRenderer sprite;
    private Transform player;
    public float offset;
    public GameObject coin;
    public int health;
    [SerializeField]private AudioClip fireSound;
    
    [SerializeField] public TopDownController user;

    void Start()
    {
        user.enemysNumber += 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        checkFlip();
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            user.enemysNumber -= 1;
            user.checkEnemys();
            Instantiate(coin, shotPoint.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }
    void checkFlip()
    {
        
        if (player != null && player.transform.position.x <= transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public void OnAnimAttack()
    {
        if (player != null)
        {
            SoundManager.instanse.PlaySound(fireSound);
            Vector3 direction = player.position - transform.position;
            float angle = Vector3.SignedAngle(direction, Vector3.right, Vector3.back);
            Instantiate(mageBolt, shotPoint.position, Quaternion.Euler(0f, 0f, angle));
        }
    }

    
}
