using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;
    private bool JumpInput;
    private bool grapInput;
    private bool isGrounded;
    private bool isTouchingWall;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingWall = player.CheckIfTouchingWall();
        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.PlayerJumpState.ResetAmountOfJumps();
    }
    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        input = player.InputHandler.MovementInput;
        JumpInput = player.InputHandler.JumpInput;
        grapInput = player.InputHandler.GrapInput;
        if (JumpInput && player.PlayerJumpState.CheckIfCanJump())
        {
            stateMachine.ChangeState(player.PlayerJumpState);
        }
        else if (!isGrounded)
        {
            player.PlayerInAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.PlayerInAirState);
        }
        else if (isTouchingWall && grapInput)
        {
            stateMachine.ChangeState(player.PlayerWallGrabState);
        }
        
    }
}
