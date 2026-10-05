using UnityEngine;

public class PlayingState : State
{
    public PlayingState(StateMachine stateMachine, GameStateFactory gameStateFactory)
    : base(stateMachine, gameStateFactory)
    {
    }

    public override void OnEnter()
    {
        // Enter logic for playing state
        GameManager.singleton.gamePaused = false;
        GameManager.singleton.gameMenu.Player_UI.SetActive(true);
        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for playing state
        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for playing state
        //GameManager.singleton.gameMenu.Player_UI.SetActive(false);
    }

    public override void CheckForTransition()
    {
        // Transition checks for playing state
        // check if the player has enough EXP to level up
        if (GameManager.singleton.current_EXP >= GameManager.singleton.EXP_to_next_lvl)
        {
            SetChildState(gameStateFactory.Upgrade());
            SwitchState(gameStateFactory.Upgrade());
            return;
        }
        else
        {
            // make sure the EXP slider is updated to reflect the current EXP and the EXP needed for the next level
            GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP;
            GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        }


        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this)
        {
            SwitchState(gameStateFactory.PauseMenu());
            return;
        }
        

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && stateMachine.CurrentState == this)
        {
            SetChildState(gameStateFactory.Moving());
            SwitchState(gameStateFactory.Moving());
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && stateMachine.CurrentState == this)
        {
            SetChildState(gameStateFactory.Idle());
            SwitchState(gameStateFactory.Idle());
        }
    }

    public override void InitializeChildState()
    {
        // Initialize any child states if applicable

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            SetChildState(gameStateFactory.Moving());
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            SetChildState(gameStateFactory.Idle());
        }
    }
}
