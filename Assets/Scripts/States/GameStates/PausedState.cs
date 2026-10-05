using System;

public class PausedState : State
{
    public PausedState(StateMachine stateMachine, GameStateFactory gameStateFactory)
        : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for paused state
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for paused state
    }

    public override void OnExit()
    {
        // Exit logic for paused state
    }

    public override void CheckForTransition()
    {
        // Transition checks for paused state
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable

        gameStateFactory.PauseMenu();
    }
}
