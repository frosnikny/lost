using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HELLEFGLWELGOEGKOIPSJGIO:SDJ");
        Debug.Log(FXSlides.Instance);
        FXSlides.Instance.gameObject.GetComponent<AudioSource>().Pause();
        // Destroy(FXSlides.Instance.gameObject.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
