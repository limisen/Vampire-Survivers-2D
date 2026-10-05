using System.Linq;
using UnityEngine;

public class GameStateRoot : State
{
    public GameStateRoot(StateMachine stateMachine, GameStateFactory gameStateFactory) : base(stateMachine, gameStateFactory)
    {
        isRootState = true;
    }

    public override void OnEnter()
    {
        // Enter logic for the root game state
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for the root game state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for the root game state
    }

    public override void CheckForTransition()
    {
        // Transition checks for the root game state
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
        SetChildState(gameStateFactory.MainMenu());
    }
}
