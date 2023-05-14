using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{  
    [SerializeField]private AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instanse.PlaySound(coinSound);
            Coin.coin+=1;
            Destroy(gameObject);
        }
    }
}
