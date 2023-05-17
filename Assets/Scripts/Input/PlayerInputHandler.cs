using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public int NormInputX  { get; private set; }    
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrapInput { get; private set; }
    [SerializeField] private float bufferJumpTimer = 0.2f;
    private float jumpInputStartTime;

    private void Update()
    {
        CheckBufferInputTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(MovementInput.x);
        NormInputY = Mathf.RoundToInt(MovementInput.y);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInputStartTime = Time.time;
            JumpInput = true;
            JumpInputStop = false;
        }
        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }
    public void OnGrapInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Ctrl has been pressed");
            GrapInput = true;
        }
        if (context.canceled)
        {
            GrapInput = false;
        }
    }
    //we made this function because it can turn to false before we make the jump action
    public void UseJumpImput() { JumpInput = false; JumpInputStop = false; }

    private void CheckBufferInputTime()
    {
        if (Time.time > jumpInputStartTime + bufferJumpTimer)
        {
            JumpInput = false;
        }
    }
}
