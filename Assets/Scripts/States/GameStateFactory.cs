using System.Collections.Generic;
using UnityEngine;

enum GameStates
{
    ParentState = -1,

    GameStateRoot,      // = 0
    
    Playing,            // = 1

    idle,               // = 2
    moving,             // = 3

    MainMenu,           // = 4
    Settings,           // = 5
    PauseMenu,          // = 6
    Upgrade,            // = 7

    GameOver,           // = 9
}

public class GameStateFactory
{
    StateMachine stateMachine;

    Dictionary<GameStates, State> stateDictionary = new Dictionary<GameStates, State>();

    public GameStateFactory(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        stateDictionary[GameStates.GameStateRoot] = new GameStateRoot(stateMachine, this);

        stateDictionary[GameStates.Playing] = new PlayingState(stateMachine, this);
        stateDictionary[GameStates.idle] = new IdleState(stateMachine, this);
        stateDictionary[GameStates.moving] = new MovingState(stateMachine, this);

        stateDictionary[GameStates.MainMenu] = new MainMenuState(stateMachine, this);
        stateDictionary[GameStates.Settings] = new SettingsState(stateMachine, this);
        stateDictionary[GameStates.PauseMenu] = new PauseMenuState(stateMachine, this);
        stateDictionary[GameStates.Upgrade] = new UpgradeState(stateMachine, this);

        stateDictionary[GameStates.GameOver] = new GameOverState(stateMachine, this);
    }

    public State GameStateRoot() { return stateDictionary[GameStates.GameStateRoot]; }

    public State Playing() { return stateDictionary[GameStates.Playing]; }
    public State Idle() { return stateDictionary[GameStates.idle]; }
    public State Moving() { return stateDictionary[GameStates.moving]; }
    
    public State MainMenu() { return stateDictionary[GameStates.MainMenu]; }
    public State Settings() { return stateDictionary[GameStates.Settings]; }
    public State PauseMenu() { return stateDictionary[GameStates.PauseMenu]; }
    public State Upgrade() { return stateDictionary[GameStates.Upgrade]; }
    
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
