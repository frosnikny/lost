using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoad : MonoBehaviour
{
    public GameObject spritePreloader;

    // Start is called before the first frame update
    void Start()
    {
        spritePreloader.transform.SetAsLastSibling();
    }
}