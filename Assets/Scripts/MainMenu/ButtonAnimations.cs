using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateAnimation()
    {
        animator.SetBool("Hovered", true);
    }
    
    public void DeactivateAnimation()
    {
        animator.SetBool("Hovered", false);
    }
}
