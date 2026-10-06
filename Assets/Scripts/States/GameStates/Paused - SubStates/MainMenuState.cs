using UnityEngine;

public class MainMenuState : State
{
    public MainMenuState(StateMachine stateMachine, GameStateFactory gameStateFactory)
        : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for main menu state
        GameManager.singleton.gamePaused = true;
        GameManager.singleton.gameMenu.Start_Menu.SetActive(true);
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for main menu state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for main menu state
        GameManager.singleton.gameMenu.Start_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for main menu state
        
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable
        SetChildState(gameStateFactory.Settings());
    }

}