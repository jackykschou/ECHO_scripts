using UnityEngine;
using System.Collections;

public class Pill : Interactable {

	public override void StartInteractionHook()
	{
		CharacterMotor motor = LevelManager.player.GetComponent("CharacterMotor") as CharacterMotor;
		motor.movement.maxForwardSpeed += 1.2f;
		motor.movement.maxBackwardsSpeed += 1.2f;
		motor.movement.maxSidewaysSpeed += 1.2f;
		gameObject.SetActive(false);
	}
	
	public override bool CheckInteractable()
	{
		return true;
	}
}
