using System.Collections.Generic;

enum GameStates
{
    GameStateRoot,
    
    Playing,

    idle,
    moving,

    Paused,
    
    MainMenu,
    Settings,
    PauseMenu,
    Upgrade,

    ViewingInventory,

    GameOver,
}

public class GameStateFactory
{
    Dictionary<GameStates, State> stateDictionary = new Dictionary<GameStates, State>();

    public GameStateFactory(State GameStateRoot)
    {
        stateDictionary[GameStates.GameStateRoot] = GameStateRoot;

        stateDictionary[GameStates.Paused] = new PausedState(this);
        stateDictionary[GameStates.Playing] = new PlayingState(this);
        stateDictionary[GameStates.idle] = new IdleState(this);
        stateDictionary[GameStates.moving] = new MovingState(this);

        stateDictionary[GameStates.MainMenu] = new MainMenuState(this);
        stateDictionary[GameStates.Settings] = new SettingsState(this);
        stateDictionary[GameStates.PauseMenu] = new PauseMenuState(this);
        stateDictionary[GameStates.Upgrade] = new UpgradeState(this);

        stateDictionary[GameStates.ViewingInventory] = new ViewingInventoryState(this);

        stateDictionary[GameStates.GameOver] = new GameOverState(this);
    }

    public State Paused() => stateDictionary[GameStates.Paused];
    public State Playing() => stateDictionary[GameStates.Playing];
    public State Idle() => stateDictionary[GameStates.idle];
    public State Moving() => stateDictionary[GameStates.moving];
    public State MainMenu() => stateDictionary[GameStates.MainMenu];
    public State Settings() => stateDictionary[GameStates.Settings];
    public State PauseMenu() => stateDictionary[GameStates.PauseMenu];
    public State Upgrade() => stateDictionary[GameStates.Upgrade];
    public State ViewingInventory() => stateDictionary[GameStates.ViewingInventory];
    public State GameOver() => stateDictionary[GameStates.GameOver];
}
