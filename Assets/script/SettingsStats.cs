
using UnityEngine;
public static class SettingsStats
{
    public const float runningSpeed = 10f;
    public const float walkingSpeed = 2f;
    public const float startSprintSpeed = 6f;
    public const float slowingDownSpeed = 3f;
    // Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;


    // player animation partameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int isSprinting;
    public static int isSlowingDown;
    public static int toolEffect;

    //shared Animations parameters
    public static int idleRight;
    public static int idleLeft;

    static SettingsStats()
    {
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        isSprinting = Animator.StringToHash("isSprinting");
        isSlowingDown = Animator.StringToHash("isSlowingDown");
        toolEffect = Animator.StringToHash("toolEffect");
        idleRight = Animator.StringToHash("idleRight");
        idleLeft = Animator.StringToHash("idleLeft");
    }
}
