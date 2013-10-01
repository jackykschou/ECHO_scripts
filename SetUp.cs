using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour {
	
	public GameObject player_cam;
	
	void Start () 
	{
		DontDestroyOnLoad(GameObject.Find("MainPlayer"));
	}
	
	public IEnumerator StartGame()
	{
		//GameObject.Find("MainPlayer").SendMessage("ChangeSize", 0.25f);
		yield return new WaitForSeconds(0.5f);
		player_cam.SetActive(true);
		Application.LoadLevel(1);	
	}
}
