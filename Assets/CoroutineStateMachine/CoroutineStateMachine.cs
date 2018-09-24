using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStateMachine : MonoBehaviour
{
    [SerializeField]
    CoroutineState[] states;

    [SerializeField]
    int currentStateIndex;

    CoroutineState currentState;
    CoroutineState nextState;

    void Start()
    {
		if(states.Length == 0){
			states = GetComponentsInChildren<CoroutineState>();
		}
		if(currentStateIndex>=states.Length){
			throw new UnityException("CoroutineStateMachine: current state index out of range");
		}
        nextState = states[currentStateIndex];
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        while (true)
        {
            OnStateChanged(nextState);
            currentState = nextState;
            currentStateIndex = System.Array.IndexOf(states, currentState);
            yield return nextState.Run(this);
        }
    }

    public void SetNextState(CoroutineState state)
    {
        OnStateChangeRequested(state);
        nextState = state;
    }

    public void SetNextState(int state)
    {
        SetNextState(states[state]);

    }

    public void GotoNextState(CoroutineState state)
    {
        SetNextState(state);
        currentState.Exit();
    }

    public void GotoNextState(int state)
    {
        SetNextState(state);
        currentState.Exit();
    }

    public virtual void OnStateChanged(CoroutineState state)
    {

    }

    public virtual void OnStateChangeRequested(CoroutineState state)
    {

    }
}
