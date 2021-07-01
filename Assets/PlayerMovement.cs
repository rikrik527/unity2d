using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class PlayerMovement : SingletonPlayer<PlayerMovement>
{
    // double click
    private const float double_click_time = .2f;
    private float lastClickTime;
    //while
    private float finishedTime = 0.5f;
    public float startTime = 0f;

    private bool isDone = false;
    public Animation animation;
    //movement parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle = false;
    private bool isRunning = false;
    private bool isWalking = false;
    private bool isSprinting = false;
    private ToolEffect toolEffect = ToolEffect.none;

    private Camera mainCamera;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float movementSpeed;

    private Direction playerDirection;

    private bool _playerInputDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputDisabled; set => _playerInputDisabled = value; }


    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        animation = GetComponentInChildren<Animation>();
        // get the reference camera
        mainCamera = Camera.main;
    }


    private void Update()
    {
        if (!PlayerInputIsDisabled)
        {
            ResetAnimationTriggers();

            PlayerMovementInput();

            PlayerRunningInput();

            // send event to any listeners for player movement input
            EventHandle.CallMovementEvent(xInput, yInput, isWalking, isRunning, isSprinting, isIdle, isCarrying, toolEffect, false, false);
        }
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }
    private void ResetAnimationTriggers()
    {
        toolEffect = ToolEffect.none;
    }
    private void PlayerMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (yInput != 0 && xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }
        if (xInput != 0 || yInput != 0)
        {

            if (!isDone)
            {
                isWalking = true;
                Debug.Log("iswalking = true");
                isRunning = false;
                isSprinting = false;
                movementSpeed = SettingsStats.walkingSpeed;
            }




            if (isSprinting == true)
            {
                Debug.Log("issprinting = true");
                isWalking = false;
                isRunning = false;
                movementSpeed = SettingsStats.startSprintSpeed;

            }
            if (isRunning == true)
            {

                Debug.Log("isrunning = true");
                isWalking = false;
                isSprinting = false;
                movementSpeed = SettingsStats.runningSpeed;
            }

            //isRunning = false;
            //isSprinting = false;
            //isWalking = true;
            //isIdle = false;
            //movementSpeed = SettingsStats.walkingSpeed;
            //Debug.Log("wrong here iswalking" + isWalking + "isruning" + isRunning + "issprinting" + isSprinting + "xinput!=0" + xInput + "yinput!=0" + yInput);



            //capture player direction for save game
            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }

        }
        else if (xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isSprinting = false;
            isIdle = true;
        }
    }
    private void PlayerRunningInput()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            isDone = true;

            StartCoroutine("StartSprint");
        }
        else
        {
            isDone = false;
        }


    }
    private void Sprint()
    {
        Debug.Log("sprint()");
        isSprinting = true;
        Invoke("Run", 0.5f);
        StopCoroutine("StartSprint");
        //while (Time.time > startTime)
        //{
        //    startTime = Time.time + finishedTime;

        //    Run();
        //    if (isRunning == true)
        //    {


        //        StopCoroutine("StartSprint");
        //        Debug.Log(isSprinting);
        //        isSprinting = false;


        //    }

        //}
    }

    private void Run()
    {

        isRunning = true;
        isSprinting = false;
    }
    private void Walk()
    {
        isWalking = true;
    }
    private IEnumerator StartSprint()
    {


        Sprint();
        yield return null;
        Debug.Log("4f");

    }


    //private void PlayerRunningInput()
    //{
    //    //pressing shift key will trigger sprint animation
    //    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
    //    {

    //        StartCoroutine(Sprint());

    //    }
    //    else if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
    //    {
    //        Debug.Log("keyup");
    //        CancelSprint();

    //    }






    //}

    //private IEnumerator Sprint()
    //{
    //    //sprint

    //    StartSprint();
    //    yield return new WaitForSeconds(1f);

    //    Debug.Log("sprinting is true" + isSprinting);
    //    isSprinting = false;
    //    Debug.Log("isSprinting" + isSprinting);
    //    // then trigger the run animation
    //    Run();




    //    //afeter 0.4seconds bool isSprinting set to false


    //}


    //private void Run()
    //{
    //    Debug.Log("running");
    //    isSprinting = false;
    //    isRunning = true;
    //    isWalking = false;
    //    isIdle = false;
    //    movementSpeed = Settings.runningSpeed;
    //}
    //private void StartSprint()
    //{
    //    Debug.Log("sprinting");
    //    isSprinting = true;
    //    isRunning = false;
    //    isWalking = false;
    //    isIdle = false;
    //    movementSpeed = Settings.isSprinting;
    //}
    //private void CancelSprint()
    //{
    //    Debug.Log("cancelsprintingandrun to walk");
    //    isSprinting = false;
    //    isRunning = false;
    //    isWalking = true;
    //    isIdle = false;
    //    movementSpeed = Settings.walkingSpeed;

    //}

}




