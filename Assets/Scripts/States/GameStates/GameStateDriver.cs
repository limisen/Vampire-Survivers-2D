using UnityEngine;

public class GameStateDriver : MonoBehaviour
{
    StateMachine stateMachine;
    State root;

    private void Awake()
    {
        root = new GameStateRoot(stateMachine);
        var builder = new StateMachineBuilder(root);
        stateMachine = builder.Build();
    }
}
