public class PauseMenuState : State
{
    //// Declaring it's childStates
    //public readonly MainMenuState mainMenu;
    //public readonly UpgradeState upgrading;
    //public readonly ViewingInventoryState viewingInventory;
    //public readonly SettingsState settings;
    //public readonly GameOverState gameOver;

    //public PauseMenuState(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    //{
    //    mainMenu = new MainMenuState(stateMachine, this);
    //    upgrading = new UpgradingState(stateMachine, this);
    //    viewingInventory = new ViewingInventoryState(stateMachine, this);
    //    settings = new SettingsState(stateMachine, this);
    //    gameOver = new GameOverState(stateMachine, this);
    //}

    //protected override State GetInitialState() => mainMenu;

    //public override void OnEnter()
    //{
    //    // Pause the Game
    //    GameManager.singleton.gamePaused = true;
    //}

    //protected override State GetTransition()
    //{
    //    // Transition logic for the Paused state
    //    if (GameManager.singleton.Player_current_HP <= 0)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return gameOver; // Transition to GameOver state if the player is dead
    //    }

    //    if (GameManager.singleton.gameMenu.Start_Menu.activeSelf)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return mainMenu; // Transition to MainMenu state if the player chooses to go to the main menu
    //    }

    //    if (GameManager.singleton.gameMenu.Settings_Menu.activeSelf)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return settings; // Transition to Settings state if the player chooses to go to the settings
    //    }

    //    if (GameManager.singleton.gameMenu.LvL_Up_Menu.activeSelf)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return upgrading; // Transition to Upgrading state if the player chooses to upgrade
    //    }

    //    if (GameManager.singleton.gameMenu.Inventory.activeSelf)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return viewingInventory; // Transition to ViewingInventory state if the player chooses to view the inventory
    //    }

    //    if (GameManager.singleton.gamePaused == false)
    //    {
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);

    //        return Parent; // Transition back to the parent state if the game is unpaused
    //    }
    //    else
    //    {
    //        // Open the pause menu
    //        GameManager.singleton.gameMenu.Pause_Menu.SetActive(true); 
    //        return null; // Stay in the Paused state if the game is still paused
    //    }
    //}

    //public override void OnUpdate(float deltaTime)
    //{
    //    base.OnUpdate(deltaTime);
    //    // Check for transitions
    //    State transitionState = GetTransition();
    //    if (transitionState != null)
    //    {
    //        Machine.Sequencer.RequestTransition(this, transitionState);
    //    }
    //}

    //public override void OnExit()
    //{
    //    // Close the pause menu
    //    GameManager.singleton.gameMenu.Pause_Menu.SetActive(false);
    //}
}
