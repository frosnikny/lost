using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Animator animator;
    
    public void ActivateDeath()
    {
        animator.SetTrigger("StartExpansion");
    }
}
