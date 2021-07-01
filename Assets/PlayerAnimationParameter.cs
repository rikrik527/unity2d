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
        EventHandle.MovementEvent += SetAnimationParameter;
    }
    private void OnDisable()
    {
        EventHandle.MovementEvent -= SetAnimationParameter;
    }
    private void SetAnimationParameter(float xInput, float yInput, bool isWalking, bool isRunning, bool isSprinting, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool idleLeft, bool idleRight)
    {
        animator.SetFloat(SettingsStats.xInput, xInput);
        animator.SetFloat(SettingsStats.yInput, yInput);
        animator.SetBool(SettingsStats.isWalking, isWalking);
        animator.SetBool(SettingsStats.isRunning, isRunning);
        animator.SetBool(SettingsStats.isSprinting, isSprinting);

        animator.SetInteger(SettingsStats.toolEffect, (int)toolEffect);
        if (idleLeft)
            animator.SetTrigger(SettingsStats.idleLeft);
        if (idleRight)
            animator.SetTrigger(SettingsStats.idleRight);
    }


}
