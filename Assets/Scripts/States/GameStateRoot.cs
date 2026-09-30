using System.Linq;
using UnityEngine;

public class GameStateRoot : State
{
    // Declaring it's childStates
    public readonly Paused paused;
    public readonly Playing playing;

    // GameStateRoot's Constructor
    public GameStateRoot(StateMachine stateMachine) : base(stateMachine, null)
    {
        paused = new Paused(stateMachine, this);
        playing = new Playing(stateMachine, this);

        ActiveChild = paused;
    }

    protected override State GetInitialState() => paused;

    protected override State GetTransition()
    {
        // If there's any menus active make sure the game is in the paused state
        if (GameManager.singleton.gameMenu.Start_Menu.activeSelf || GameManager.singleton.gameMenu.Settings_Menu.activeSelf || GameManager.singleton.gameMenu.GameOver_Menu.activeSelf || GameManager.singleton.gameMenu.Pause_Menu.activeSelf || GameManager.singleton.gameMenu.LvL_Up_Menu.activeSelf)
        {
            ActiveChild = paused;
            return paused;
        }
        else
        {
            ActiveChild = playing;
            return playing;
        }
    }
}
