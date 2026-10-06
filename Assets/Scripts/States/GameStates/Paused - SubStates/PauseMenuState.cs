using UnityEngine;

public class PauseMenuState : State
{
    public PauseMenuState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for viewing the pause Menu, state
        GameManager.singleton.gamePaused = true;
        GameManager.singleton.gameMenu.Pause_Menu.SetActive(true);
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for viewing the pause Menu, state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for viewing the pause Menu, state
        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for viewing the pause Menu, state

        // Basically if we are already viewing the Pause Menu and press 'ESC' then close the menu and enter 'Playing'State
        if (GameManager.singleton.gameMenu.Pause_Menu.activeSelf && stateMachine.CurrentState == this && Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Changing State to Playing");
            SwitchState(gameStateFactory.Playing());
            return;
        }
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable
        SetChildState(gameStateFactory.Settings());
    }

}
