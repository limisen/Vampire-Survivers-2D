using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public readonly State Root;
    public readonly TransitionSequencer Sequencer;

    bool started;

    public StateMachine(State root)
    {
        Root = root;
        Sequencer = new TransitionSequencer(this);
    }


    private void Start()
    {
        if (started) return;

        started = true;
        Root.Enter();
    }

    public void Tick(float deltaTime)
    {
        if (!started) Start();

        InternalTick(deltaTime);
    }

    internal void InternalTick(float deltaTime) => Root.Update(deltaTime);


    // Preform the actual switch 'from' to 'to' by exiting up to the shared ancestor, then entering down to the target
    public void ChangeState(State from, State to)
    {
        if (from == to || from == null || to == null) return;

        State lca = TransitionSequencer.LCA(from, to);

        // Exit current branch up to (but not including) LCA
        for (State state = from; state != lca; state = state.Parent) state.Exit();

        // Enter target branch from LCA down to the target
        var stack = new Stack<State>();
        for (State state = to; state != lca; state = state.Parent, stack.Push(state));
        while (stack.Count > 0) stack.Pop().Enter();
    }
}