using UnityEngine;

public class Move : State
{
    public Move(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    {

    }

    public override void OnEnter()
    {
        // IF we have any velocity and/or are holding down a movement key make sure to get into this state.
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);


    }

    public override void OnExit()
    {
        // IF we have pressed ESC to open the pause menu, Go to Pause

        // IF we have pressed a key to open the Inventory, Go to ViewInventory

        // IF we aren't holding down any movement key, enter idle
    }
}
