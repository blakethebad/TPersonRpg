using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    Animator animator;
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

    }

    public void SetMovementAnimation(Vector3 movement)
    {

        if (movement.magnitude != 0)
        {
            if (playerInput.isJogging)
            {
                animator.SetFloat("movementInput", 1f,0.12f,Time.deltaTime);
            }
            else if (!playerInput.isJogging)
            {
                animator.SetFloat("movementInput", 0.5f,0.12f,Time.deltaTime);
            }
        }
        else
        {
            animator.SetFloat("movementInput", 0f, 0.12f, Time.deltaTime);
        }
        
    }

    public void SetAimMovementAnimation(Vector3 movement)
    {
        animator.SetFloat("aimInputX", movement.x);
        animator.SetFloat("aimInputZ", movement.z);
    }

    public void SetAimAnimationBool(bool aimBool)
    {
        animator.SetBool("isAiming",aimBool);
    }
    public void SetJogAnimationBool(bool jogBool)
    {
        
    }

}
