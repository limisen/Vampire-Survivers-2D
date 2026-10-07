using UnityEngine;

public class MovingState : State
{
    public MovingState(StateMachine stateMachine, GameStateFactory gameStateFactory)
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

        if ((Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0) && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Changing State to Idle");

            CheckForTransition();

            SwitchState(gameStateFactory.Idle());
        }
        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Pause (ESC) was pressed");

            GameManager.singleton.gameMenu.Player_UI.SetActive(false); // We are no longer in a "Playing" State so turn off Player_UI

            CheckForTransition();

            SwitchState(gameStateFactory.PauseMenu());
        }
    }

    public override void OnExit()
    {
        // Exit logic for idle state
    }

    public override void CheckForTransition()
    {
        // Transition checks for idle state
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
    }
}
