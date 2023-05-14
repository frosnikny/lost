using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBolt : MonoBehaviour
{
    public float speed;
    public float distance;
    public float lifetime;
    public int damage;
    public LayerMask whatIsSolid;
    public TopDownController main_sprite;
    public SpriteRenderer sprite;
    private Transform player;
    List<Sprite> throwSprite;

    
    float buffTime;
    bool flag;
    float posX;
    float posY;
    bool flip;

    void Start()
    {
        throwSprite = main_sprite.lastSprite;
        buffTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        flip = main_sprite.spriteRenderer.flipX;
    }

    void Update()
    {
        if (gameObject.name == "MagicFire(Clone)" && player != null)
        {
            if (Time.time - buffTime > lifetime)
            {
                sprite.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX, posY, 0),
                    speed * Time.deltaTime);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
