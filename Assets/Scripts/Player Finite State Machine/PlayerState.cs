using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startedTime;
    protected bool isAnimationFinished;
    protected bool isExitingState;
    // TODO add a variable for the animation boolean name
    public PlayerState (Player player, PlayerStateMachine stateMachine,PlayerData playerData)
    {
        this.player = player;
        this.playerData = playerData;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() {
        DoChecks();
        startedTime = Time.time;
        Debug.Log(stateMachine.CurrentState.ToString());
        isAnimationFinished = false;
        isExitingState = false;
    }
    public virtual void Exit() {
        isExitingState = true;
    }
    public virtual void LogicalUpdate() { }
    public virtual void PhysicalUpdate() {
        DoChecks();
    }
    public virtual void DoChecks() { }

    public virtual void AnimationTriggers() { }

    // trigger this function if you want to wait the animation to end before moving to next state 
    // you can trigger this animation by animation event
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
