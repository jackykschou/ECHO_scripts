using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public static bool boosted = false;
	public Fader fade_in;
	public Fader fade_out;
	public static int current_level;
	public Transform start_pos;
	public static GameObject player;
	public static PlayerSoundManager player_sound_manager;
	public static LevelManager manager;
	
	public static float default_speed;
	public static float default_jump;
	
	void Start()
	{
		Screen.showCursor = false;
		manager = (GameObject.Find("LevelManager").GetComponent("LevelManager")) as LevelManager;
		player_sound_manager = (GameObject.Find("MainPlayer").GetComponent("PlayerSoundManager")) as PlayerSoundManager;
		current_level = Application.loadedLevel;
		player = GameObject.Find("MainPlayer");
		player.transform.position = start_pos.transform.position;
		fade_in.FadeIn();
		player.tag = "Player";
		CharacterMotor motor = LevelManager.player.GetComponent("CharacterMotor") as CharacterMotor;
		if(current_level == 3 && !boosted)
		{
			boosted = true;
			motor.movement.maxForwardSpeed += 0.5f;
			motor.movement.maxBackwardsSpeed += 0.5f;
			motor.movement.maxSidewaysSpeed += 0.5f;
			motor.jumping.baseHeight += 0.02f;
			motor.jumping.extraHeight += 0.02f;
			
			default_speed = motor.movement.maxForwardSpeed;
			default_jump = motor.jumping.baseHeight;
		}
		else if(current_level == 3)
		{
			motor.movement.maxForwardSpeed = default_speed;
			motor.movement.maxBackwardsSpeed = default_speed;
			motor.movement.maxSidewaysSpeed = default_speed;
			motor.jumping.baseHeight = default_jump;
			motor.jumping.extraHeight = default_jump;
		}
		
	}
	
	public static void ChangeLevel(int level)
	{
		manager.ChangeLevelHelper(level);
	}
	
	void ChangeLevelHelper(int level)
	{
		fade_out.FadeOut();
		if(current_level == 4)
		{
			Application.LoadLevel(4);
		}
		else
		{
			Inventory.ClearItmes();
			player.tag = "";
			StartCoroutine(DelayChangeLevel(level));
		}
	}
	
	public static void AdvanceLevel()
	{
		player.SendMessage("ChangeSize", 0.5f);
		manager.ChangeLevelHelper(++current_level);
	}
	
	public void AdvanceLevelHelper()
	{
		ChangeLevelHelper(++current_level);
	}
	
	public static void RestartLevel()
	{
		manager.ChangeLevelHelper(current_level);
	}
	
	public void RestartLevelHelper()
	{
		ChangeLevelHelper(current_level);
	}
	
	IEnumerator DelayChangeLevel(int level)
	{
		yield return new WaitForSeconds(0.3f);
		Application.LoadLevel(level);
	}
	
}
