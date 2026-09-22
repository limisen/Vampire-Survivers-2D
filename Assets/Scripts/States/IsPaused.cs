using UnityEngine;

public class IsPaused : State
{
    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.singleton.gamePaused = false;
            StateMachine.singleton.SwitchState<IsPlaying>();
        }
    }
}
