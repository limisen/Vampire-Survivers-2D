using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;
    GameStateFactory stateMachine;

    [SerializeField] string currentStateName;
    [SerializeField] string currentParentStateName;
    [SerializeField] string StatePath;
    public State CurrentState { get { return currentState; } set { currentState = value; } }

    private void Awake()
    {
        stateMachine = new GameStateFactory(this);

        currentState = stateMachine.GameStateRoot();
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
    }

    public void ChangeStateViaButton(int stateIndex)
    {
        Debug.Log("Changing state via button pressed...");
        // Check if the stateIndex is 10, (which corresponds to the UI "Back" button being pressed),
        // which means we need to go back to the previous state.
        // aka the parent state of the current state.
        if (stateIndex == 10)
        {
            currentState.ChangeState(currentState.CurrentParentState);
            if (currentState == stateMachine.GameStateRoot() && currentState.CurrentParentState != null)
            {
                currentState.CurrentParentState = null;
            }
            currentState = currentState.CurrentParentState;
            currentStateName = currentState.ToString();
        }
        else
        {
            State newState;
            newState = stateMachine.GetState(stateIndex);
            currentState.ChangeState(newState);
            currentState = newState;
        }
        Debug.Log("State changed to: " + currentStateName);
    }
}