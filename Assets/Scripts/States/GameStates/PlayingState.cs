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
        Debug.Log("Entering state: " + this.GetType().Name);

        GameManager.singleton.gamePaused = false;
        GameManager.singleton.gameMenu.Player_UI.SetActive(true);

        InitializeChildState();
    }

    public override void OnUpdate()
    {
        // Update logic for playing state

        // IF the player has dropped to 0 or below enter GameOver State:
        if (GameManager.singleton.Player_current_HP <= 0 && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Player has Died!");
            
            CheckForTransition();
            
            GameManager.singleton.gameMenu.Player_UI.SetActive(false);
            SwitchState(gameStateFactory.GameOver());
            return;
        }

        // Check if the player has enough EXP to level up
        if (GameManager.singleton.current_EXP >= GameManager.singleton.EXP_to_next_lvl && GameManager.singleton.gamePaused == false)
        {
            Debug.Log("Changing State to Upgrade");
            
            CheckForTransition();

            GameManager.singleton.gameMenu.Player_UI.SetActive(false);
            SwitchState(gameStateFactory.Upgrade());
            return;
        }

        // IF the Player is not at maxHP (and the game is unpaused) perform the HP regen
        if (GameManager.singleton.Player_current_HP < GameManager.singleton.Player_MaxHP && GameManager.singleton.gamePaused == false)
        {
            GameManager.singleton.Player_current_HP += GameManager.singleton.Player_HP_regen * Time.deltaTime;
        }

        // Update the Player UI
        GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP;
        GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;
    }

    public override void OnExit()
    {
        // Exit logic for playing state
    }

    public override void CheckForTransition()
    {
        // Transition checks for playing state
    }

    public override void InitializeChildState()
    {
        SetChildState(gameStateFactory.Idle());
        SetChildState(gameStateFactory.Moving()); 
        SetChildState(gameStateFactory.Upgrade());
    }
}
