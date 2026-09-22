using UnityEngine;

public class GameOver : State
{
    private PlayerData Player;
    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>();        
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (Player.current_HP <= 0)
        {
            GameManager.singleton.gamePaused = true;
            StateMachine.singleton.SwitchState<GameOver>();
        }
    }
}
