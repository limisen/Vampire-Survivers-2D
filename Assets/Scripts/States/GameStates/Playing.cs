using UnityEngine;

public class Playing : State
{
    public readonly Idle idle;
    public readonly Move move;

    public Playing(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {
        idle = new Idle(stateMachine, this);
        move = new Move(stateMachine, this);
    }

    protected override State GetInitialState() => idle;

    public override void OnEnter()
    {
        GameManager.singleton.gamePaused = true;
    }
}
