using UnityEngine;
using System.Collections;

public class ChairLock : Interactable {
	
	public float slide_speed;
	public GameObject chair;
	public Transform destination;
	int key_index;
	public bool unlocked = false;
	
	public AudioClip sliding;
	
	public override void StartInteractionHook()
	{
		unlocked = true;
		AudioSource.PlayClipAtPoint(sliding, transform.position);
		Inventory.UseItem(key_index);
		transform.Translate(1000f, 0f, 0f);
	}
	
	public override bool CheckInteractable()
	{
		int i = 0;
		bool own_key = false;
		foreach(Collectable c in Inventory.items)
		{
			if(c != null && c.collectable_name == "chair_key")
			{
				own_key = true;
				key_index = i;
			}
			++i;
		}
		return own_key;
	}
	
	void Update()
	{
		if(unlocked)
		{
			Debug.Log("move");
			chair.transform.position = Vector3.Lerp(chair.transform.position, destination.position, slide_speed * Time.deltaTime);
		}
	}
}
