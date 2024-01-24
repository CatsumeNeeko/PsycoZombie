using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Networking;
    

public class PlayerMovement : NetworkBehaviour
{
    [Header("Dependancies")]
    public GameManager gameManager;
    [Header("MovementStats")]
    public float moveSmoothTime;
    public float gravityStrength;
    public float jumpStrength;
    public float walkSpeed;
    public float runSpeed;
    public Vector2 sensitivity;
    public Transform PlayerCamera;
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVeloctiy;
    private Vector3 CurrentForceVeloctiy;
    private Vector2 XYRotation;
    private PlayerState currentPlayerState = PlayerState.Idle;
    [Header("Animations")]
    Animator animator;


    public NetworkVariable<int> team;


    public enum PlayerState
    {
        Idle,
        Walking,
        Sprinting
    }

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    TestServerRpc();
        //}

        Vector2 MouseInput = new()
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y"),
        };
        XYRotation.x -= MouseInput.y * sensitivity.y;
        XYRotation.y += MouseInput.x * sensitivity.x;
        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);
        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);

        Vector3 PlayerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector * CurrentSpeed, ref MoveDampVeloctiy, moveSmoothTime);

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);

        Ray grondcheckray = new(transform.position, Vector3.down);
        if (Physics.Raycast(grondcheckray, 1.1f))
        {
            CurrentForceVeloctiy.y = -2f;

            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVeloctiy.y = jumpStrength;
            }
        }
        else
        {
            CurrentForceVeloctiy.y -= gravityStrength * Time.deltaTime;
        }
        Controller.Move(CurrentForceVeloctiy * Time.deltaTime);
        //UpdateAnimator();
    }
}
