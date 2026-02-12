//? -------- what / why --------
//? Owns the current player state and routes lifecycle calls to it.
//? Stores a reference to the PlayerController context so states can read movement data.

using UnityEngine;

public class PlayerStateMachine
{
    //? -------- context / factory --------

    public PlayerController Context { get; }
    public PlayerStateFactory Factory { get; }

    PlayerBaseState currentState;

    public PlayerBaseState CurrentState => currentState;

    public PlayerStateMachine(PlayerController context)
    {
        Context = context;
        Factory = new PlayerStateFactory(this);
    }

    //? -------- state control -------- Initialize and switch.

    public void Initialize(PlayerBaseState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    //? -------- lifecycle routing -------- Called from PlayerController.

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void LogicUpdate()
    {
        currentState?.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}

