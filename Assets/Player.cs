using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private float finishedTime = 0.4f;
    public float startTime = 0f;
    private bool isDone = false;
    //movement parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isRunning;
    private bool isWalking;
    private bool isSprinting;
    private ToolEffect toolEffect = ToolEffect.none;

    private Camera mainCamera;

    private Rigidbody2D rigidbody2D;

    private float movementSpeed;

    private Direction playerDirection;

    private bool _playerInputDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputDisabled; set => _playerInputDisabled = value; }


    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();

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
            EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isSprinting, isIdle, isCarrying, toolEffect, false, false);
        }
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
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

            isRunning = false;
            isSprinting = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
            Debug.Log("wrong here");

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
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && isSprinting == false)
        {
            isSprinting = true;

            Sprint();





            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                Debug.Log("keyup");
                isRunning = false;
                isSprinting = false;
                isWalking = true;
                isIdle = false;
                movementSpeed = Settings.walkingSpeed;
            }
        }
        else if (isSprinting == true && isRunning == false)
        {
            isSprinting = false;
            Run();
        }


    }
    private void Sprint()
    {
        Debug.Log("sprint");


        isRunning = false;
        isWalking = false;
        isIdle = false;
        movementSpeed = Settings.startSprintSpeed;
        while (Time.time > startTime)
        {

            startTime = Time.time + finishedTime;
            if (Run())
            {

            }
            Run();
        }


    }

    private bool Run()
    {
        Debug.Log("Run");
        isRunning = true;

        isWalking = false;
        isIdle = false;
        movementSpeed = Settings.runningSpeed;
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

