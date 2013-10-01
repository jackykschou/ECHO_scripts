using UnityEngine;
using System.Collections;

public class DoorLock : Interactable {
	
	public DoorRotate door;
	public AudioClip deny_sound;
	int key_index;
	
	public override void StartInteractionHook()
	{
		door.OpenDoor();
		Inventory.UseItem(key_index);
		LevelManager.AdvanceLevel();
	}
	
	public override bool CheckInteractable()
	{
		int i = 0;
		bool own_key = false;
		foreach(Collectable c in Inventory.items)
		{
			if(c != null && c.collectable_name == "key")
			{
				own_key = true;
				key_index = i;
			}
			++i;
		}
		if(!own_key)
		{
			AudioSource.PlayClipAtPoint(deny_sound, transform.position);	
		}
		return own_key;
	}
}
