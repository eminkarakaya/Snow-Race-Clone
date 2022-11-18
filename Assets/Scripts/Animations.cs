using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void RollSnowAnim()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
    }
    public void DeathAnim()
    {
        animator.SetTrigger("Death");
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
    }
    public void IdleAnim()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Idle", true);
    }
    public void Dance()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
        
        animator.SetTrigger("Win");
    }
}
