using UnityEngine;
using System.Collections;

public class CharacterControllerModifier: MonoBehaviour {

	public CharacterMotor motor;
	public Transform character;
	public CharacterBobbing bobbing;
	public CharacterInteraction interaction;
	
	public void ChangeSize(float size)
	{
		character.transform.localScale *= size;
		ChangeMotor(size);
		bobbing.o_amount *= size;
		interaction.cast_range *= size;
	}
	
	public void ChangeMotor(float size)
	{
		motor.movement.maxFallSpeed *= size;
		motor.movement.maxForwardSpeed *= size;
		motor.movement.maxBackwardsSpeed *= size;
		
		motor.jumping.baseHeight *= size;
		motor.jumping.extraHeight *= size;
	}
}
