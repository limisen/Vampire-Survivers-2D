using UnityEngine;

public class MovingState : State
{
    public MovingState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for moving state
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for moving state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for moving state
    }

    public override void CheckForTransition()
    {
        // Transition checks for moving state
        if ((Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0) && stateMachine.CurrentState == this)
        {
            SwitchState(gameStateFactory.Idle());
        }
        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this)
        {
            SwitchState(gameStateFactory.PauseMenu());
        }
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
    }
}
