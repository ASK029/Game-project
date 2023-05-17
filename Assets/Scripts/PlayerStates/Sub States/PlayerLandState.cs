using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if (!isExitingState)
        {
            if (input.x != 0)
            {
                stateMachine.ChangeState(player.PlayerMoveState);
            }
            else
            {
                stateMachine.ChangeState(player.PlayerIdleState);
            }
        }
    }

}
