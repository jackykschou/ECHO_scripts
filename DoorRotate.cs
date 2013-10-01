using UnityEngine;
using System.Collections;

public class DoorRotate : MonoBehaviour {

	// Use this for initialization
	
	
	public float door_speed;
	public GameObject open;
	private bool openn = false;
	private Quaternion rot;
	
	void Start () {
		rot = transform.rotation;
		
	}
	
	//Opens the door
    public void OpenDoor()
    {
        openn = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(openn)
		{
			transform.rotation = Quaternion.Slerp (rot, open.transform.rotation,door_speed*Time.deltaTime);
		}
		
		
	}
}
