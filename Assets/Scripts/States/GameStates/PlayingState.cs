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

        // IF the player wishes to pause
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Pause (ESC) was pressed");

            GameManager.singleton.gameMenu.Player_UI.SetActive(false);

            Debug.Log("Changing State to PauseMenu");

            CheckForTransition();

            SwitchState(gameStateFactory.PauseMenu());
            return;
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

            Debug.Log("Playing Player_Death_SFX...");
            GameManager.singleton.MasterAudioSource.PlayOneShot(GameManager.singleton.Player_Death_SFX, 5);
            SwitchState(gameStateFactory.GameOver());
        }

        // IF the player is moving, go to the moving state:
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            
                SetChildState(gameStateFactory.Moving());

            CheckForTransition();

            Debug.Log("Changing State to Moving");
            SwitchState(gameStateFactory.Moving());
        }
        // Else go to idle state
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            
                SetChildState(gameStateFactory.Idle());

            CheckForTransition();

            Debug.Log("Changing State to Idle");
            SwitchState(gameStateFactory.Idle());
        }
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
        SetChildState(gameStateFactory.Settings());
    }
}
