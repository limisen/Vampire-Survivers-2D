using System.Linq;
using UnityEngine;

public class GameStateRoot : State
{
    // Define it's childStates
    public readonly Paused paused;
    public readonly Playing playing;

    // GameStateRoot's Constructor
    public GameStateRoot(StateMachine stateMachine) : base(stateMachine, null)
    {
        paused = new Paused(stateMachine, this);
        playing = new Playing(stateMachine, this);
    }

    protected override State GetInitialState() => paused;

    public override void OnEnter()
    {
        
    }
}
