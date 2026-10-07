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
        Debug.Log("Entering state: " + this.GetType().Name);

        GameManager.singleton.gamePaused = true;
        GameManager.singleton.gameMenu.Pause_Menu.SetActive(true);
        
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for viewing the pause Menu, state

        // Basically if we are already viewing the Pause Menu and the player presses 'ESC' then close the menu and enter 'Playing'State
        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == true)
        {
            CheckForTransition();

            Debug.Log("Changing State to Playing");
            SwitchState(gameStateFactory.Playing());
        }

    }

    public override void OnExit()
    {
        // Exit logic for viewing the pause Menu, state
        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for viewing the pause Menu, state

        
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable
        SetChildState(gameStateFactory.Settings());
    }

}
