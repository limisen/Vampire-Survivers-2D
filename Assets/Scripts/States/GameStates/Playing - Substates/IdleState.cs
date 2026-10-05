using UnityEngine;

public class IdleState : State
{
    public IdleState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for idle state
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for idle state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for idle state
    }

    public override void CheckForTransition()
    {
        // Transition checks for idle state
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && stateMachine.CurrentState == this)
        {
            SwitchState(gameStateFactory.Moving());
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
