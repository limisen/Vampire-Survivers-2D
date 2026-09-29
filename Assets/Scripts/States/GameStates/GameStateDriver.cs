using System.Linq;
using UnityEngine;

public class GameStateDriver : MonoBehaviour
{
    StateMachine stateMachine;
    State root;
    [SerializeField] string LastPath;
    private void Awake()
    {
        root = new GameStateRoot(stateMachine);
        StateMachineBuilder builder = new(root);
        stateMachine = builder.Build();
    }

    private void Update()
    {
        LastPath = StatePath(root.Leaf());
    }

    // Get the path to the provided state via PathToRoot() then reversing that list.
    public static string StatePath(State s)
    {
        return string.Join(" > ", s.PathToRoot().Reverse().Select(n => n.GetType().Name));
    }
}
