using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;
    GameStateFactory stateMachine;

    [SerializeField] string currentStateName;
    [SerializeField] string currentParentStateName;
    public State CurrentState { get { return currentState; } set { currentState = value; } }

    private void Awake()
    {
        stateMachine = new GameStateFactory(this);

        currentState = stateMachine.MainMenu();
        currentState.OnEnter();
    }

    private void Update()
    {
        currentState?.UpdateStates();
    }

    private void LateUpdate()
    {
        if (currentState.ToString() == currentStateName)
        {
            return;
        }
        else
        {
            currentStateName = currentState.ToString();
        }

        if (currentState.CurrentParentState?.GetType().Name == currentParentStateName)
        {
            return;
        }
        else if (currentState.CurrentParentState == null)
        {
            currentParentStateName = "null";
        }
        else
        {
                currentParentStateName = currentState.CurrentParentState?.GetType().Name;
        }
    }

    public void ChangeState(int stateIndex)
    {
        
        // Check if the stateIndex is 11, which corresponds to the UI "Back" button, which means we need to go back to the previous state. aka the parent state of the current state.
        if (stateIndex == 11)
        {
            currentState.ChangeState(currentState.CurrentParentState);
            currentState = currentState.CurrentParentState;
        }
        else
        {
            State newState;
            newState = stateMachine.GetState(stateIndex);
            currentState.ChangeState(newState);
            currentState = newState;
        }
    }
}