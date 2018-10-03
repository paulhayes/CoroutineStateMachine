using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateUpdateRoutine 
{
	IEnumerator StateUpdate(CoroutineStateMachine machine);
	
}
