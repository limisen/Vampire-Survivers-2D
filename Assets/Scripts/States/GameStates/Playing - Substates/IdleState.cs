using UnityEngine;

public class IdleState : State
{
    public IdleState(StateMachine stateMachine, GameStateFactory gameStateFactory)
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

        // Check IF the player tries to pause
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Pause (ESC) was pressed");

            CheckForTransition();

            GameManager.singleton.gameMenu.Player_UI.SetActive(false);
            SwitchState(gameStateFactory.PauseMenu());
            return;
        }

        // Check if the player has enough EXP to level up
        if (GameManager.singleton.current_EXP >= GameManager.singleton.EXP_to_next_lvl)
        {
            CheckForTransition();

            SwitchState(gameStateFactory.Upgrade());
        }

        // Check if the Player Can Regen HP
        if (GameManager.singleton.Player_current_HP < GameManager.singleton.Player_MaxHP)
        {
            GameManager.singleton.Player_current_HP += GameManager.singleton.Player_HP_regen * Time.deltaTime;
        }

        // Update HP UI
        GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;
        GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP;

        // Has the Player died?
        if (GameManager.singleton.Player_current_HP <= 0)
        {
            Debug.Log("Player Died...");

            CheckForTransition();

            GameManager.singleton.gameMenu.Player_UI.SetActive(false);

            SwitchState(gameStateFactory.GameOver());
        }

        // IF the player is moving, go to the moving state:
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            CheckForTransition();

            //Debug.Log("Changing State to Moving");
            SwitchState(gameStateFactory.Moving());
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
        SetChildState(gameStateFactory.Settings());
    }
}
