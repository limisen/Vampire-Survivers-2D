using UnityEngine;

public class Idle : State
{
    public Idle(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {
        
    }
    public override void OnEnter()
    {
        // set player's velocity to zero.
        
    }
    public override void OnExit()
    {

    }
}
