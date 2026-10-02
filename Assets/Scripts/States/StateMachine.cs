using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState;
    public GameStateFactory GameStateFactory => new GameStateFactory(this);
}