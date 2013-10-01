using UnityEngine;
using System.Collections;

public class Collectable : Interactable {
	
	public string collectable_name;
	public bool assigned = false;
	
	public override void StartInteractionHook()
	{
		int i = 0;
		foreach(Collectable c in Inventory.items)
		{
			if(c == null && !assigned)
			{
				assigned = true;
				transform.Translate(1000f, 0f, 0f);
				Inventory.items[i] = this;
			}
			++i;
		}
	}
	
	public override bool CheckInteractable()
	{
		return true;
	}
}
