using UnityEngine;

public class SettingsState : State
{
    public SettingsState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for settings state
        GameManager.singleton.gameMenu.Settings_Menu.SetActive(true);
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for settings state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for settings state
        GameManager.singleton.gameMenu.Settings_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for settings state
        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this)
        {
            Debug.Log("Pause (ESC) was pressed");
            Debug.Log("Changing State to ParentState");
            SwitchState(currentParentState);
            return;
        }
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable
    }
}
