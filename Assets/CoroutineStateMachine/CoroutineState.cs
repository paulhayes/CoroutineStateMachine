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
		yield return StateBegin();
        while (!exit){
            StateUpdate(stateMachine);
            yield return null;
        }
		yield return StateEnd();
    }

	public virtual IEnumerator StateBegin()
	{
		yield break;
	}

    public virtual void StateUpdate(CoroutineStateMachine stateMachine)
    {

    }

	public virtual IEnumerator StateEnd()
	{
		yield break;
	}

    public void Exit()
    {
        exit = true;
    }

}

