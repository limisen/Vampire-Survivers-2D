using UnityEngine;

public class GameOverState : State
{
    public GameOverState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for game over state
        Debug.Log("Entering state: " + this.GetType().Name);

        GameManager.singleton.gamePaused = true;
        GameManager.singleton.gameMenu.GameOver_Menu.SetActive(true);

        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for game over state
        CheckForTransition();
    }


    public override void OnExit()
    {
        // Exit logic for game over state
        GameManager.singleton.gameMenu.GameOver_Menu.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for game over state
    }

    public override void InitializeChildState()
    {
        // Initialize any substates if applicable
        SetChildState(gameStateFactory.Settings());
    }

}
