using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    public InitState InitState;

    private void Awake()
    {
        InitState = new InitState(this);
    }

    protected override BaseState GetInitialState()
    {
        return InitState;
    }
}
