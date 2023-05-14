using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Transform main_char;
    public TopDownController main_sprite;
    public SpriteRenderer sprite;
    [SerializeField]private AudioClip throwSound;

    // Start is called before the first frame update

    public GameObject spearBullet;
    public Transform shotPoint;
    public CircleCollider2D circle;
    void Start()
    {
        transform.position = new Vector3(main_char.position.x, main_char.position.y + 0.1f,main_char.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (main_sprite!=null && main_sprite.spriteRenderer.flipX == true )
        {
            sprite.flipX = true;
        }
        else sprite.flipX = false;
        sprite_update();
        throw_spear();
        
    }

    void throw_spear()
    {
        if (main_sprite!=null && Input.GetKeyDown(KeyCode.Space) && sprite.gameObject.activeSelf)
        {
            SoundManager.instanse.PlaySound(throwSound);
            sprite.gameObject.SetActive(false);
            spearBullet.gameObject.SetActive(true);
            // Instantiate(spearBullet, shotPoint.position, transform.rotation()
            if (main_sprite.lastSprite == main_sprite.nSprites)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,-55f));
            } 
            else if (main_sprite.lastSprite == main_sprite.sSprites)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,125f));

            }
            else if (main_sprite.lastSprite == main_sprite.neSprites && sprite.flipX == false)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,-100f));

            }
            else if (main_sprite.lastSprite == main_sprite.neSprites && sprite.flipX == true)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,-10f));

            }
            else if (main_sprite.lastSprite == main_sprite.eSprites && sprite.flipX == false)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,-145f));

            }
            else if (main_sprite.lastSprite == main_sprite.eSprites && sprite.flipX == true)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,35f));

            }
            else if (main_sprite.lastSprite == main_sprite.seSprites && sprite.flipX == false)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,-190f));

            }
            else if (main_sprite.lastSprite == main_sprite.seSprites && sprite.flipX == true)
            {
                Instantiate(spearBullet, shotPoint.position, Quaternion.Euler(0f,0f,105f));

            }
        }
    }
    
    void sprite_update()
    {
        if (main_sprite != null)
        {
            if (main_sprite.lastSprite == main_sprite.nSprites)
            {
                transform.position =
                    new Vector3(main_char.position.x, main_char.position.y - 0.1f, main_char.position.z);
                transform.localScale = new Vector3(0.63f, 1.43f, 0);
            }
            else if (main_sprite.lastSprite == main_sprite.sSprites)
            {
                transform.position =
                    new Vector3(main_char.position.x, main_char.position.y + 0.1f, main_char.position.z);
                transform.localScale = new Vector3(0.84f, 1.80f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.neSprites && sprite.flipX == false)
            {
                transform.position = new Vector3(main_char.position.x - 0.1f, main_char.position.y - 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.neSprites && sprite.flipX == true)
            {
                transform.position = new Vector3(main_char.position.x + 0.1f, main_char.position.y - 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.eSprites && sprite.flipX == false)
            {
                transform.position = new Vector3(main_char.position.x - 0.25f, main_char.position.y + 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.eSprites && sprite.flipX == true)
            {
                transform.position = new Vector3(main_char.position.x + 0.25f, main_char.position.y + 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.seSprites && sprite.flipX == false)
            {
                transform.position = new Vector3(main_char.position.x - 0.3f, main_char.position.y + 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
            else if (main_sprite.lastSprite == main_sprite.seSprites && sprite.flipX == true)
            {
                transform.position = new Vector3(main_char.position.x + 0.3f, main_char.position.y + 0.1f,
                    main_char.position.z);
                transform.localScale = new Vector3(0.4540272f, 1.268603f, 0);

            }
        }
    }
}
