using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string name;
    protected StateMachine StateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.StateMachine = stateMachine;
    }
    
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysicsLogic() { }
    public virtual void Exit() { }

}
