public abstract class State
{
    protected StateMachine stateMachine; // Context for the states
    protected GameStateFactory gameStateFactory;

    protected bool isRootState; // Flag to indicate if this is the root state

    protected State currentChildState; // Reference to the child state
    protected State currentParentState; // Reference to the parent state

    public State CurrentChildState { get { return currentChildState; } set { currentChildState = value; } }
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
        if (currentChildState != null) { currentChildState.UpdateStates(); }
    }

    public void ExitStates()
    {
        OnExit();
        if (currentChildState != null) { currentChildState.ExitStates(); }
    }

    protected void SwitchState(State newState) 
    { 
        if (newState.isRootState) 
        {
            ExitStates();
            newState.OnEnter();
        }
        else 
        {
            OnExit();
            newState.OnEnter();
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
        currentChildState = newChildState;
        newChildState.SetParentState(this);
    }

}
