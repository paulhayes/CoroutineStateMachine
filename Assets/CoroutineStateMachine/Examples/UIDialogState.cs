using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class UIDialogState : CoroutineState
{
	[SerializeField]
	GameObject ui;

	void Awake()
	{
		ui.SetActive(false);
	}
	public override IEnumerator StateBegin()
	{		
		ui.SetActive(true);
		yield break;
	}

	public override IEnumerator StateEnd()
	{
		ui.SetActive(false);
		yield break;
	}
}
