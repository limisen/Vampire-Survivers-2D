using UnityEngine;

public class ViewingInventoryState : State
{
    public ViewingInventoryState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for viewing inventory state
        GameManager.singleton.gamePaused = true;
        InitializeChildState();
        // Toggle this menu's visability (aka GameObject) ON
    }

    public override void OnUpdate()
    {
        // Update logic for viewing inventory state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for viewing inventory state
        // Toggle this menu's visability (aka GameObject) ON
    }

    public override void CheckForTransition()
    {
        // Transition checks for viewing inventory state
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
    }
}
