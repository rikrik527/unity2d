
using UnityEngine;
public static class Settings
{
    public const float runningSpeed = 10f;
    public const float walkingSpeed = 2f;
    public const float startSprintSpeed = 5f;


    // player animation partameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int isSprinting;
    public static int toolEffect;

    //shared Animations parameters
    public static int idleRight;
    public static int idleLeft;

    static Settings()
    {
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        isSprinting = Animator.StringToHash("isSprinting");
        toolEffect = Animator.StringToHash("toolEffect");
        idleRight = Animator.StringToHash("idleRight");
        idleLeft = Animator.StringToHash("idleLeft");
    }
}
