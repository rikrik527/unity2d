using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationParameter : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameter;
    }
    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameter;
    }
    private void SetAnimationParameter(float xInput, float yInput, bool isWalking, bool isRunning, bool isSprinting, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool idleLeft, bool idleRight)
    {
        animator.SetFloat(Settings.xInput, xInput);
        animator.SetFloat(Settings.yInput, yInput);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);
        animator.SetBool(Settings.isSprinting, isSprinting);

        animator.SetInteger(Settings.toolEffect, (int)toolEffect);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
    }


}
