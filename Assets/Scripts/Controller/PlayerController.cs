using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public JumpState jumpState;
    public IdleState idleState;
    public RunState runState;
    public KneelState kneelState;

    State state;

    public Animator animator;

    // scene instanced objects
    public Camera mainCamera;
    public Rigidbody body;
    public BoxCollider groundCheck;
    public LayerMask groundMask;

    // movement properties
    public float acceleration;
    [Range(0f, 1f)]
    public float groundDecay;
    public float maxXSpeed;

    // passed to the State from Init(this)
    public bool grounded { get; private set; }
    public float xInput { get; private set; }
    public float yInput { get; private set; }

    void Start()
    {
        jumpState.Init(body, animator, this);
        idleState.Init(body, animator, this);
        runState.Init(body, animator, this);
        kneelState.Init(body, animator, this);

        state = idleState;
    }

    void Update()
    {
        InputHandler();

        SelectState();

        state.Do();
    }

    void SelectState()
    {
        State oldState = state;

        if (grounded)
        {
            if (yInput < 0 && Mathf.Abs(xInput) < 0.1f)
            {
                state = kneelState;
            }
            else if (xInput == 0)
            {
                state = idleState;
            }
            else
            {
                state = runState;
            }
        }
        else
        {
            state = jumpState;
        }

        // Perform only if the current state and the previous state are different.
        if (oldState != state || !oldState.isCompelete)
        {
            oldState.Exit();
            state.Initialize();
            state.Enter();
        }
    }

    void InputHandler()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsGround", false);
        }
    }
}
