//? -------- what / why --------
//? Creates and caches concrete player state instances.
//? Ensures we do not allocate new states every frame when switching.

using UnityEngine;

public class PlayerStateFactory
{
    readonly PlayerStateMachine machine;

    PlayerIdleState idleState;
    PlayerMoveState moveState;

    public PlayerStateFactory(PlayerStateMachine machine)
    {
        this.machine = machine;
    }

    public PlayerBaseState Idle()
    {
        return idleState ??= new PlayerIdleState(machine);
    }

    public PlayerBaseState Move()
    {
        return moveState ??= new PlayerMoveState(machine);
    }
}

