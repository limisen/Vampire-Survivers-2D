using UnityEngine;

public class UpgradeState : State
{
    public UpgradeState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for upgrade state
        GameManager.singleton.gamePaused = true;
        GameManager.singleton.gameMenu.LvL_Up_Menu.SetActive(true);
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for upgrade state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for upgrade state
        GameManager.singleton.gameMenu.LvL_Up_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for upgrade state
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
    }
}
