using UnityEngine;

public class MovingState : State
{
    public MovingState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for moving state
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for moving state
        CheckForTransition();

        // check if the player has enough EXP to level up
        if (GameManager.singleton.current_EXP >= GameManager.singleton.EXP_to_next_lvl)
        {
            SwitchState(gameStateFactory.Upgrade());
            stateMachine.CurrentState = gameStateFactory.Playing();
        }
        else if (GameManager.singleton.gamePaused == false)
        {
            // make sure the EXP slider is updated to reflect the current EXP and the EXP needed for the next level
            GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP;
            GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        }
    }

    public override void OnExit()
    {
        // Exit logic for moving state
    }

    public override void CheckForTransition()
    {
        // Transition checks for moving state
        if ((Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0) && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Changing State to Idle");
            SwitchState(gameStateFactory.Idle());
        }
        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Pause (ESC) was pressed");
            GameManager.singleton.gameMenu.Player_UI.SetActive(false);
            SwitchState(gameStateFactory.PauseMenu());
        }
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable
    }
}
