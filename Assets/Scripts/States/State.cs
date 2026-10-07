using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State
{
    protected StateMachine stateMachine; // Context for the states
    protected GameStateFactory gameStateFactory;

    protected bool isRootState; // Flag to indicate if this is the root state

    protected List<State> currentChildStates = new(); // Reference to the child state(s)
    protected State currentParentState; // Reference to the parent state

    // implement setter for this List of ChildStates
    public List<State> CurrentChildStates { get { return currentChildStates; } }
    public State CurrentParentState { get { return currentParentState; } set { currentParentState = value; } }


    public State(StateMachine stateMachine, GameStateFactory gameStateFactory)
    {
        this.stateMachine = stateMachine;
        this.gameStateFactory = gameStateFactory;
    }


    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();


    public abstract void CheckForTransition();
    public abstract void InitializeChildState();

    public void UpdateStates() 
    {
        OnUpdate();
        if (currentChildStates.Count != 0) 
        {
            for (int i = 0; i < currentChildStates.Count; i++)
            {
                currentChildStates[i].UpdateStates();                
            }
        }
    }

    public void ExitStates()
    {
        if (currentChildStates.Count != 0) 
        {
            Debug.Log($"Child State Exists, Exiting them first before exiting current state...");
            for (int i = 0; i < currentChildStates.Count; i++)
            {
                currentChildStates[i].ExitStates();
            }
        }

        Debug.Log("Exiting state: " + this.GetType().Name);
        OnExit();
    }


    protected void SwitchState(State newState) 
    {
        if (newState.isRootState) 
        {
            // IF the new state is the root state, exit all states then enter the root (again)
            ExitStates();
            newState.OnEnter();
        }
        else if (currentChildStates.Contains(newState))
        {
            // IF the new state is a child of the current state, enter that child state.
            newState.OnEnter();
        }
        else if (newState == currentParentState)
        {
            // IF the new state is a parent of this state exit this state then re-enter that state.
            OnExit();
            newState.OnEnter();
        }
        else if (currentParentState.currentChildStates.Contains(newState))
        {
            // IF the new state is a child of the parent. Exit this state and make the parent enter the child state.
            OnExit();
            currentParentState.ChangeState(newState);
        }
        else
        {
            // Else Exit all states and re enter the root state
            ExitStates();
            gameStateFactory.GameStateRoot().OnEnter();
            gameStateFactory.GameStateRoot().SetChildState(newState);
        }
        stateMachine.CurrentState = newState;
    }

    public void ChangeState(State newState)
    {
        SwitchState(newState);
    }

    protected void SetParentState(State newParentState) 
    {
        currentParentState = newParentState;
    }

    public void SetChildState(State newChildState) 
    {
        if (currentChildStates.Count != 0)
        {
            if (currentChildStates.Contains(newChildState))
            {
                return;
            }
            else
            {
                currentChildStates.Add(newChildState);
                newChildState.SetParentState(this);
            }
        }
        else
        {
            currentChildStates.Add(newChildState);
            newChildState.SetParentState(this);
        }
    }

}
