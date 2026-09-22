using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    [SerializeField] public bool gamePaused = true;

    private void Awake()
    {
        if (singleton != null)
        {
            Destroy(this);
            return;
        }

        singleton = this;
    }

    private void Start()
    {
        // set the state we to be the state we should be in at the launch of the game.
        StateMachine.singleton.SwitchState<Viewing_a_Menu>();
    }

    private void Update()
    {
        StateMachine.singleton.UpdateStateMachine();
    }
}