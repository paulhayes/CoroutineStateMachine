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
        
        if( this is IStateBeginCallback ){
            (this as IStateBeginCallback).StateBegin();
        }
        if( this is IStateBeginRoutine ){
            yield return (this as IStateBeginRoutine).StateBegin();
        }
        
        bool hasUpdateCallback = ( this is IStateUpdateCallback ); 
        bool hasUpdateRoutine = ( this is IStateUpdateRoutine );
        while (!exit){
            if(hasUpdateCallback){
                ((IStateUpdateCallback)this).StateUpdate(stateMachine);
            }
            if(hasUpdateRoutine){
                yield return (this as IStateUpdateRoutine).StateUpdate(stateMachine);
            } 
            yield return null;
        }
        

        if( this is IStateEndRoutine ){
            yield return (this as IStateEndRoutine).StateEnd();
        }
        if( this is IStateEndCallback ){
            (this as IStateEndCallback).StateEnd();
        }
       
    }

    public void Exit()
    {
        exit = true;
    }

}

