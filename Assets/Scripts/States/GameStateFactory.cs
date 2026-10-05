using System.Collections.Generic;
using UnityEngine;

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

    ParentState,
}

public class GameStateFactory
{
    StateMachine stateMachine;

    Dictionary<GameStates, State> stateDictionary = new Dictionary<GameStates, State>();

    public GameStateFactory(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        stateDictionary[GameStates.GameStateRoot] = new GameStateRoot(stateMachine, this);

        stateDictionary[GameStates.Paused] = new PausedState(stateMachine, this);
        stateDictionary[GameStates.Playing] = new PlayingState(stateMachine, this);
        stateDictionary[GameStates.idle] = new IdleState(stateMachine, this);
        stateDictionary[GameStates.moving] = new MovingState(stateMachine, this);

        stateDictionary[GameStates.MainMenu] = new MainMenuState(stateMachine, this);
        stateDictionary[GameStates.Settings] = new SettingsState(stateMachine, this);
        stateDictionary[GameStates.PauseMenu] = new PauseMenuState(stateMachine, this);
        stateDictionary[GameStates.Upgrade] = new UpgradeState(stateMachine, this);

        stateDictionary[GameStates.ViewingInventory] = new ViewingInventoryState(stateMachine, this);

        stateDictionary[GameStates.GameOver] = new GameOverState(stateMachine, this);
    }

    public State GameStateRoot() { return stateDictionary[GameStates.GameStateRoot]; }

    public State Paused() { return stateDictionary[GameStates.Paused]; }
    public State Playing() { return stateDictionary[GameStates.Playing]; }
    public State Idle() { return stateDictionary[GameStates.idle]; }
    public State Moving() { return stateDictionary[GameStates.moving]; }
    
    public State MainMenu() { return stateDictionary[GameStates.MainMenu]; }
    public State Settings() { return stateDictionary[GameStates.Settings]; }
    public State PauseMenu() { return stateDictionary[GameStates.PauseMenu]; }
    public State Upgrade() { return stateDictionary[GameStates.Upgrade]; }
    
    public State ViewingInventory() { return stateDictionary[GameStates.ViewingInventory]; }
    
    public State GameOver() { return stateDictionary[GameStates.GameOver]; }

    public State ParentState() { return stateDictionary[GameStates.ParentState]; }


    public State GetState(int state)
    {
        for (int i = 0; i < System.Enum.GetValues(typeof(GameStates)).Length; i++)
        {
            if (i == state)
            {
                return stateDictionary[(GameStates)i];
            }
        }
        Debug.LogError("State not found: " + state);
        return null;
    }
}
