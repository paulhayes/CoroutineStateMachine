using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class ExampleUIDialogState : CoroutineState, IStateBeginCallback, IStateEndCallback
{
	[SerializeField]
	GameObject ui;

	void Awake()
	{
		ui.SetActive(false);
	}
	public void StateBegin()
	{		
		Debug.Log("State Begin");
		Debug.Log(Time.frameCount);
		ui.SetActive(true);
	}

	public void StateEnd()
	{
		Debug.Log("StateEnd");
		Debug.Log(Time.frameCount);
		ui.SetActive(false);
	}
}
