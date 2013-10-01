using UnityEngine;
using System.Collections;

public class Book : Interactable {
	
	public GameObject key;
	
	public override void StartInteractionHook()
	{
		key.SetActive(true);
		gameObject.SetActive(false);
	}
	
	public override bool CheckInteractable()
	{
		return true;
	}
}
