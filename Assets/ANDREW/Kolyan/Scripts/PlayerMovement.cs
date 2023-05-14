using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move_h, move_v;
    [SerializeField] private float move_speed = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move_h = Input.GetAxisRaw("Horizontal") * move_speed;
        move_v = Input.GetAxisRaw("Vertical") * move_speed;
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        rb.velocity = new Vector2(move_h, move_v * 0.5f);
    }
}
