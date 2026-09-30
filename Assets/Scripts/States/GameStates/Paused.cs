using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Paused : State
{
    // Declaring it's childStates
    public readonly MainMenu mainMenu;
    public readonly Upgrading upgrading;
    public readonly ViewingInventory viewingInventory;
    public readonly Settings settings;
    public readonly GameOver gameOver;

    public Paused(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {
        mainMenu = new MainMenu(stateMachine, this);
        upgrading = new Upgrading(stateMachine, this);
        viewingInventory = new ViewingInventory(stateMachine, this);
        settings = new Settings(stateMachine, this);
        gameOver = new GameOver(stateMachine, this);

        ActiveChild = mainMenu;
    }

    protected override State GetInitialState() => mainMenu;

    public override void OnEnter()
    {
        base.OnEnter();

        // Pause the Game
        GameManager.singleton.gamePaused = true;

        // Open the pause menu
    }

    protected override State GetTransition()
    {
        if (GameManager.singleton.Player_current_HP <= 0)
        {
            ActiveChild = gameOver;
            return gameOver;
        }

        else
        {
            ActiveChild = null;
            return null;
        }
    }


    public override void OnExit()
    {
        // Close the menu(s)

        // Unpause the game
        GameManager.singleton.gamePaused = false;

        // Enter the Playing State
        
    }
}
