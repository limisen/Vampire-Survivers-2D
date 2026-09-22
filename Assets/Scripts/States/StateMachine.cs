using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // A list of GameStates as set via the Unity Inspector
    public List<State> GameStates = new List<State>();
    public State Current_GameState = null;

    public static StateMachine singleton;
    private void Awake()
    {
        if (singleton != null)
        {
            Destroy(this);
            return;
        }

        singleton = this;
    }

    // Switch the current state to the provided state as long as it exists
    public void SwitchState<A_GameState>()
    {
        foreach (State state in GameStates)
        {
            if (state.GetType() == typeof(A_GameState))
            {
                Current_GameState?.ExitState();
                Current_GameState = state;
                Current_GameState.EnterState();
                return;
            }
        }

        Debug.LogError("State does NOT exist");
    }

    public virtual void UpdateStateMachine()
    {
        Current_GameState?.UpdateState();
    }

    public bool Is_GameState<A_GameState>()
    {
        if (!Current_GameState) return false;
        return Current_GameState.GetType() == typeof(A_GameState);
    }
}
