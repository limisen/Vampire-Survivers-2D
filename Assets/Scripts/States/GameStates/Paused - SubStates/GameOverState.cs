using UnityEngine;

public class GameOverState : State
{
    //public GameOverState(StateMachine stateMachine, State Parent) : base(stateMachine, Parent)
    //{

    //}

    //public override void OnEnter()
    //{
    //    GameManager.singleton.gamePaused = true;
    //}

    //protected override State GetTransition()
    //{
    //    // Game over logic here
    //    // Transition logic for the GameOver state
    //    if (GameManager.singleton.gamePaused == false)
    //    {
    //        return Parent; // Transition back to the parent state if the game is unpaused
    //    }
    //    else
    //    {
    //        GameManager.singleton.gameMenu.GameOver_Menu.SetActive(true);
    //        return null; // Stay in the Paused state if the game is still paused
    //    }
    //}

    //public override void OnExit()
    //{
    //    GameManager.singleton.gameMenu.GameOver_Menu.SetActive(false);
    //}
}
