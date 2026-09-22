using UnityEngine;

public class IsPlaying : State
{
    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.singleton.gamePaused = true;
            StateMachine.singleton.SwitchState<IsPaused>();
        }
    }
}
