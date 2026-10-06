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
        //InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for playing state
        
        if (GameManager.singleton.Player_current_HP <= 0 && GameManager.singleton.gamePaused == false)
        {
            SwitchState(gameStateFactory.GameOver());
        }

        // Player Regen Logic
        if (GameManager.singleton.Player_current_HP < GameManager.singleton.Player_MaxHP && GameManager.singleton.gamePaused == false)
        {
            GameManager.singleton.Player_current_HP += GameManager.singleton.Player_HP_regen * Time.deltaTime;
        }
        GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;

        CheckForTransition();
    }

    public override void OnExit()
    {
        // Exit logic for playing state
    }

    public override void CheckForTransition()
    {
        // Transition checks for playing state
        
        // check if the player has enough EXP to level up
        if (GameManager.singleton.current_EXP >= GameManager.singleton.EXP_to_next_lvl && GameManager.singleton.gamePaused == false)
        {
            SetChildState(gameStateFactory.Upgrade());
            Debug.Log("Changing State to Upgrade");
            SwitchState(gameStateFactory.Upgrade());
            //stateMachine.CurrentState = gameStateFactory.Upgrade();
            return;
        }
        else if (GameManager.singleton.gamePaused == false)
        {
            // make sure the EXP slider is updated to reflect the current EXP and the EXP needed for the next level
            GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP;
            GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        }


        if (Input.GetButtonDown("Cancel") && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Pause (ESC) was pressed");
            GameManager.singleton.gameMenu.Player_UI.SetActive(false);
            Debug.Log("Changing State to PauseMenu");
            SwitchState(gameStateFactory.PauseMenu());
            return;
        }
        
        // IF the player is moving, go to the moving state:
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            if (currentChildState != gameStateFactory.Moving())
            {
                SetChildState(gameStateFactory.Moving());
            }
            Debug.Log("Changing State to Moving");
            SwitchState(gameStateFactory.Moving());
        }
        // Else go to idle state
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && stateMachine.CurrentState == this && GameManager.singleton.gamePaused == false)
        {
            if (currentChildState != gameStateFactory.Idle())
            {
                SetChildState(gameStateFactory.Idle());
            }
            Debug.Log("Changing State to Idle");
            SwitchState(gameStateFactory.Idle());
        }
    }

    public override void InitializeChildState()
    {
    }
}
