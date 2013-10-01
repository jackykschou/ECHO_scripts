using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour {
	
	public bool interacted = false;
	public AudioClip interact_sound;
	
	public void StartInteraction()
	{
		if(!interacted && CheckInteractable())
		{
			interacted = true;
			AudioSource.PlayClipAtPoint(interact_sound, transform.position);
			StartInteractionHook();
		}
	}
	
	public abstract void StartInteractionHook();
	
	public abstract bool CheckInteractable();
		
}
