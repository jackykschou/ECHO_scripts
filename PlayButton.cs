using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	
	public bool clicked = false;
	public SetUp setup;
	
	public void OnClick()
	{
		if(!clicked)
		{
			clicked = true;
			StartCoroutine(setup.StartGame());
		}
	}
	
}
