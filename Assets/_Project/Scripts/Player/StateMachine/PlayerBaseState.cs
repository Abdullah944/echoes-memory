//? -------- what / why --------
//? Base type for all player states in the state machine.
//? Holds a reference to the shared PlayerStateMachine and defines the state API.

using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateMachine Machine { get; }

    protected PlayerBaseState(PlayerStateMachine machine)
    {
        Machine = machine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void HandleInput();
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
}

