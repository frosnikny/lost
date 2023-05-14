using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathToLevel : MonoBehaviour
{
    public Animator animator;
    
    public void DeathFade()
    {
        animator.SetTrigger("DeathOut");
    }
}
