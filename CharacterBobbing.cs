using UnityEngine;
using System.Collections;

public class CharacterBobbing : MonoBehaviour {

	public float bob_amount;
	public float current_bob = 0f;
	public bool up = true; //true == up, false == down
	public float bob_speed;
	public Camera cam;
	public Transform cam_default_pos;
	public CharacterMotor motor;
	public CharacterController controller;
	public float o_amount = 0.15f;
	
	public AudioClip[] walk_sounds;
	public AudioClip[] jump_sounds;
	
	void Start()
	{
		cam_default_pos.transform.localPosition = cam.transform.localPosition;
	}
	
	void Update()
	{
		if(controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			AudioSource.PlayClipAtPoint(jump_sounds[UnityEngine.Random.Range(0, 3)], transform.position);
		}
		
		if(controller.velocity == Vector3.zero)
		{
			cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, cam_default_pos.transform.localPosition, bob_speed);
		}
		else
		{
			if(current_bob >= 1.0f)
			{
				if(controller.isGrounded)
					AudioSource.PlayClipAtPoint(walk_sounds[UnityEngine.Random.Range(0, 4)], transform.position);
				up = true;
			}
			else if(current_bob <= -1f)
			{
				if(controller.isGrounded)
					AudioSource.PlayClipAtPoint(walk_sounds[UnityEngine.Random.Range(0, 4)], transform.position);
				up = false;
			}
			
			if(up)
			{
				current_bob -= 0.06f;
			}
			else
			{
				current_bob += 0.06f;
			}
			
			if(up)
			{
				cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, cam.transform.localPosition + new Vector3(0, bob_amount, 0), bob_speed);
			}
			else
			{
				cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, cam.transform.localPosition + new Vector3(0, -bob_amount, 0), bob_speed);
			}
		}
	}
}
