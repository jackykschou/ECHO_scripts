using UnityEngine;
using System.Collections;

public class Ruler : Interactable {

	public override void StartInteractionHook()
	{
		transform.Rotate(0, 0, 0);
	}
	
	public override bool CheckInteractable()
	{
		return true;
	}
}
