using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChar : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;
    public float lifetime;
    public LayerMask whatIsSolid;
    public TopDownController main_sprite;
    public Spear spear;
    public SpriteRenderer sprite;
     List<Sprite> throwSprite;

     float buffTime;
     float posX;
     float posY;
     bool flip;
     bool flag;
    private void Start()
    {
        throwSprite = main_sprite.lastSprite;
        buffTime = Time.time;
        posX = spear.transform.position.x;
        posY = spear.transform.position.y;
        flip = spear.sprite.flipX;
    }

    private void Update()
    {
        if (gameObject.name == "ThrowSpear(Clone)")
        {
        if (Time.time - buffTime > lifetime)
        {
            if (flag == false)
            {
                spear.gameObject.SetActive(true);
                sprite.gameObject.SetActive(false);
                flag = true;
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    hitInfo.collider.GetComponent<TestWalking>().TakeDamage(damage);
                    spear.gameObject.SetActive(true);
                    sprite.gameObject.SetActive(false);
                }

                if (hitInfo.collider.CompareTag("Mage"))
                {
                    hitInfo.collider.GetComponent<MageAttack>().TakeDamage(damage);
                    spear.gameObject.SetActive(true);
                    sprite.gameObject.SetActive(false);
                }
                if (hitInfo.collider.CompareTag("Wall"))
                {
                    spear.gameObject.SetActive(true);
                    sprite.gameObject.SetActive(false);
                    Debug.Log("Pizdec");
                }
            }

            if (throwSprite == main_sprite.nSprites)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX, +10000f), speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.sSprites)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX, -10000f), speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.neSprites && flip == false)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX + 10000f, posY + 10000f),
                    speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.neSprites && flip == true)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX - 10000f, posY + 10000f),
                    speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.eSprites && flip == false)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(10000f, posY), speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.eSprites && flip == true)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(-10000f, posY), speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.seSprites && flip == false)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX + 10000f, posY - 10000f),
                    speed * Time.deltaTime);
            }
            else if (throwSprite == main_sprite.seSprites && flip == true)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(posX - 10000f, posY - 10000f),
                    speed * Time.deltaTime);
            }
        }
        }
    }

   


}
