using UnityEngine;

public class Playing : State
{
    // Declaring it's childStates
    public readonly Idle idle;
    public readonly Move move;

    public Playing(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {
        idle = new Idle(stateMachine, this);
        move = new Move(stateMachine, this);

        ActiveChild = idle;
    }

    protected override State GetInitialState() => idle;

    public override void OnEnter()
    {
        GameManager.singleton.gamePaused = false;

        GameManager.singleton.gameMenu.Player_UI.SetActive(true);
    }

    protected override State GetTransition()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            return idle;
        }
        else return move;
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (GameManager.singleton.Player_current_HP <= 0)
        {
            Machine.Sequencer.RequestTransition(this, Parent);
            return;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Machine.Sequencer.RequestTransition(this, idle);
        }
        else Machine.Sequencer.RequestTransition(this, move);
    }

    public override void OnExit()
    {
        GameManager.singleton.gameMenu.Player_UI.SetActive(false);
    }
}
