public abstract class State
{
    
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();


    public abstract void CheckForTransition();
    public abstract void InitializeSubState();

    void UpdateStates() { }

    void SwitchState(State newState) 
    { 
        OnExit();

        newState.OnEnter();
        
    }

    void SetSuperState() { }

    void SetSubState() { }

}
