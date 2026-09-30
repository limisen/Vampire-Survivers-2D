using UnityEngine;

public class MainMenu : State
{
    public readonly Settings settings;
    public MainMenu(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {
        settings = new Settings(stateMachine, this);

    }

    public override void OnEnter()
    {
        GameManager.singleton.gameMenu.Start_Menu.SetActive(true);
    }

    protected override State GetTransition()
    {
        // Main menu logic here

        // if settings pressed go into settings
        // return settings;

        return null;
    }

    public override void OnExit()
    {
        GameManager.singleton.gameMenu.Start_Menu.SetActive(false);
    }
}