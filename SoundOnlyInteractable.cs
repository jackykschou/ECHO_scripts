using UnityEngine;
using System.Collections;

public class SoundOnlyInteractable : Interactable {
	
	public float sound_counter = 0f;
	
	public override void StartInteractionHook()
	{
		sound_counter = interact_sound.length + 0.2f;
		LevelManager.player_sound_manager.PlayInteraction(interact_sound);
		interacted = false;
	}
	
	public override bool CheckInteractable()
	{
		return sound_counter <= 0f;
	}
	
	void Update()
	{
		if(sound_counter > 0f)
		{
			sound_counter -= Time.deltaTime;	
		}
	}
	
}
