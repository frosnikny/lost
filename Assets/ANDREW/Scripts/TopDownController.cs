using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;

    public Healthbar healthbar;
    public int maxHealth = 20;
    public int currentHealth;
    public int damage;
    public Animator anim;
    
    public List<Sprite> lastSprite;
    List<Sprite> buff = null;
    public float walkSpeed;

    [SerializeField]private AudioClip walkSound;
    [SerializeField]private AudioClip deathSound;
    [SerializeField]private AudioClip hurtSound;


    public float frameRate;

    private MagicBolt bolt;

    [SerializeField] public DeathScreen scr;
    [SerializeField] public LevelChangerButton scrWin;

    public int enemysNumber = 0;

    public void checkEnemys()
    {
        if (enemysNumber == 0)
        {
            // Debug.Log("HOW ARE YOU");
            scrWin.FadeToLevel();
        }
    }
    
    float idleTime;
    // Start is called before the first frame update
    Vector3 direction;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        body.velocity = direction * walkSpeed;
        
        HandleSpriteFlip();

        SetSprite();
        OnAnimationEnd();

        if (currentHealth <= 0)
        {
            SoundManager.instanse.PlaySound(deathSound);
            scr.ActivateDeath();
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Magic"))
        {
            TakeDamage(5);
            Debug.Log(5);
            Destroy(other.gameObject);
        }
    }

    void SetSprite()
    {
        List<Sprite> directionSprites = GetSpriteDirection();
        if (directionSprites != null)
        {
            
            float playTime = Time.time - idleTime;
            int totalFrames = (int)(playTime * frameRate);
            int frame = totalFrames % directionSprites.Count;
            spriteRenderer.sprite = directionSprites[frame];
            lastSprite = directionSprites;
            buff = directionSprites;
        }
        else
        {
            if (buff!=null)
            {
                spriteRenderer.sprite = lastSprite[1];
            }
            idleTime = Time.time;
        }
    }
    
    void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void OnAnimationEnd()
    {
        if (anim != null && anim.GetBool("Attack") == true && anim.GetBool("AnimEnd"))
        {
            anim.SetBool("AnimEnd",false);
            TakeDamage(5);
            Debug.Log(maxHealth);
        }
    }
    
    public void TakeDamage(int damage)
    {
        SoundManager.instanse.PlaySound(hurtSound);
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    public List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;
        
        if (direction.y > 0)
        {
            if (Math.Abs(direction.x) > 0)
            {
                selectedSprites = neSprites;
            }
            else
            {
                selectedSprites = nSprites;
            }
        } else if (direction.y < 0)
        {
            if (Math.Abs(direction.x) > 0)
            {
                selectedSprites = seSprites;
            }
            else
            {
                selectedSprites = sSprites;
            }
        }
        else
        {
            if (Math.Abs(direction.x) > 0)
            {
                selectedSprites = eSprites;
            }
        }

        return selectedSprites;
    }
}