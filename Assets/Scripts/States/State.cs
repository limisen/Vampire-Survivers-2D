using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State
{
    public readonly StateMachine Machine;

    public readonly State Parent;

    public State ActiveChild;


    public State(StateMachine stateMachine, State Parent = null)
    {
        this.Machine = stateMachine;
        this.Parent = Parent;
    }

    // Which child should we enter first? This decides the answer to that.
    protected virtual State GetInitialState() => null; // Inital child to enter when this state starts (IF (state = null) then this is the "leaf" of the tree)
    // Do we want to switch this frame? This decides the answer to that.
    protected virtual State GetTransition() => null; // Target state to switch to this frame (IF (state = null) then stay in the current state)


    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate(float deltaTime) { }


    internal void Enter()
    {
        // Making sure the Parent OnEnter() runs first before the child's
        if (Parent != null) Parent.ActiveChild = this;

        OnEnter();

        // IF a init state exists and is defined enter that state
        State init = GetInitialState(); 
        if (init != null) init.Enter();
    }
    internal void Exit()
    {
        // Making sure the Child's OnExit() runs first before the Parent's
        if (ActiveChild != null) ActiveChild.Exit();

        ActiveChild = null;
        OnExit();
    }
    internal void Update(float deltaTime)
    {
        State t = GetTransition();
        if (t != null)
        {
            Machine.Sequencer.RequestTransition(this, t);
            return;
        }

        if (ActiveChild != null) ActiveChild.Update(deltaTime);
        OnUpdate(deltaTime);
    }

    // Return the deepest currently-active decendant state (aka the "leaf" of this branch)
    public State Leaf()
    {
        State state = this;
        while (state.ActiveChild != null) state = state.ActiveChild;
        return state;
    }

    // Get the path to the root through each state (this -> parent -> ... -> root)
    public IEnumerable<State> PathToRoot()
    {
        for (State state = this; state != null; state = state.Parent) yield return state;
    }
}
