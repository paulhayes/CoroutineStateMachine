using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoroutineState : MonoBehaviour
{
    protected bool exit = false;

    protected CoroutineStateMachine stateMachine;

    public virtual IEnumerator Run(CoroutineStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        exit = false;
        if( this is IStateBeginRoutine ){
            yield return (this as IStateBeginRoutine).StateBegin();
        }
        if( this is IStateBeginCallback ){
            (this as IStateBeginCallback).StateBegin();
        }
        
        while (!exit){
            StateUpdate(stateMachine);
            yield return null;
        }


        if( this is IStateEndRoutine ){
            yield return (this as IStateEndRoutine).StateEnd();
        }
        if( this is IStateEndCallback ){
            (this as IStateEndCallback).StateEnd();
        }
        
    }



    public virtual void StateUpdate(CoroutineStateMachine stateMachine)
    {

    }



    public void Exit()
    {
        exit = true;
    }

}

