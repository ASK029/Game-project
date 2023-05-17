using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        player.CheckIfCanFlip((int)input.x);
        player.SetVelocityX(playerData.movementVelocity * input.x);
        if (input.x == 0 && !isExitingState)
        {
            stateMachine.ChangeState(player.PlayerIdleState);
        }
    }

    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
}
