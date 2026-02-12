//? -------- what / why --------
//? This file does one task: own the player state machine and input.
//? It reads movement input via the Unity Input System, updates the state machine,
//? and exposes clean data for animation (IsMoving, LastFacingDirection).

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //? -------- movement settings -------- Inspector.

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] InputActionReference moveActionRef;

    //? -------- state / cache -------- Not shown in Inspector.

    Rigidbody2D rb;
    Animator animator;
    PlayerStateMachine stateMachine;

    Vector2 moveInput;
    Vector2 lastFacingDirection;

    //? -------- public API (for states / animation) -------- Read-only.

    public Rigidbody2D Rb => rb;
    public Animator Animator => animator;
    public float MoveSpeed => moveSpeed;
    public Vector2 MoveInput => moveInput;
    public Vector2 LastFacingDirection => lastFacingDirection;
    public bool IsMoving => moveInput.sqrMagnitude > 0.01f;

    //? -------- Unity lifecycle -------- Init, update state machine.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastFacingDirection = Vector2.down;

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        stateMachine.Initialize(stateMachine.Factory.Idle());
    }

    void Update()
    {
        if (moveActionRef != null && moveActionRef.action != null)
            moveInput = moveActionRef.action.ReadValue<Vector2>();

        stateMachine.HandleInput();
        stateMachine.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    //? -------- helpers for states -------- Facing direction.

    public void UpdateFacingDirection(Vector2 input)
    {
        if (input.sqrMagnitude > 0.01f)
            lastFacingDirection = input.normalized;
    }
}

