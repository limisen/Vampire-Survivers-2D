using UnityEngine;

public class GameOver : State
{
    public GameOver(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {

    }

    public override void OnEnter()
    {
        GameManager.singleton.gamePaused = true;
    }
}
