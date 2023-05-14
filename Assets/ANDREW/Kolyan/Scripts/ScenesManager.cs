using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool wasOakAngry = (DialogueManager
            .GetInstance()
            .GetVariableState("was_oak_angry") as Ink.Runtime.Value);
        //UnityEngine.Debug.Log("wasOakAngry: " + wasOakAngry);
    }
}
