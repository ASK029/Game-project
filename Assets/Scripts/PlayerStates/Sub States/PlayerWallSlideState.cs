using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if (!isExitingState)
        {
            player.SetVelocityY(-playerData.wallSlideVelocity);
            if (grapInput && yInput == 0 && !isExitingState)
            {
                stateMachine.ChangeState(player.PlayerWallGrabState);
            }
        }
    }
}
