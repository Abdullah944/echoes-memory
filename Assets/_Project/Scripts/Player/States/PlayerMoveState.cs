//? -------- what / why --------
//? Move state: handle 8-direction movement using Rigidbody2D.
//? Reads input from the PlayerController context and applies velocity in FixedUpdate.

using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine machine) : base(machine) { }

    public override void Enter()
    {
        // Nothing special on enter yet.
    }

    public override void Exit()
    {
        // Stop movement when leaving the move state.
        Machine.Context.Rb.linearVelocity = Vector2.zero;
    }

    public override void HandleInput()
    {
        if (!Machine.Context.IsMoving)
            Machine.SwitchState(Machine.Factory.Idle());
    }

    public override void LogicUpdate()
    {
        if (Machine.Context.IsMoving)
            Machine.Context.UpdateFacingDirection(Machine.Context.MoveInput);
    }

    public override void PhysicsUpdate()
    {
        Vector2 input = Machine.Context.MoveInput;

        // Normalize if the magnitude is greater than 1 (diagonal input).
        if (input.sqrMagnitude > 1f)
            input = input.normalized;

        Machine.Context.Rb.linearVelocity = input * Machine.Context.MoveSpeed;
    }
}

