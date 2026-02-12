//? -------- what / why --------
//? Idle state: player is not providing movement input.
//? Keeps the hero still and switches to Move when input appears.

using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine machine) : base(machine) { }

    public override void Enter()
    {
        // Ensure we do not drift when entering idle.
        Machine.Context.Rb.linearVelocity = Vector2.zero;
    }

    public override void Exit()
    {
        // Nothing special when leaving idle (yet).
    }

    public override void HandleInput()
    {
        if (Machine.Context.IsMoving)
            Machine.SwitchState(Machine.Factory.Move());
    }

    public override void LogicUpdate()
    {
        // No per-frame logic while idle for now.
    }

    public override void PhysicsUpdate()
    {
        // Keep velocity at zero while idle.
        Machine.Context.Rb.linearVelocity = Vector2.zero;
    }
}

