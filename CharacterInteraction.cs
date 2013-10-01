using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour {
	
	public CharacterController controller;
	RaycastHit hit;
	public int layer = (1 << 8); 
	public float cast_range;
	
	void Update () 
	{
		RaycastHit hit;
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(Physics.Raycast(transform.position, transform.forward, out hit, cast_range, layer) && controller.isGrounded)
			{
				hit.transform.gameObject.SendMessage("StartInteraction");
			}
		}
	}
}
