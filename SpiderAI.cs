using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour {
	
	public Animator animator;
	
	public float movement_speed;
	public float detection_range;
	public AudioClip walk_sound;
	public AudioClip eat_sound;
	public AudioClip player_panic;
	public Nest nest;
	public bool chase;
	public bool go_eat;
	public bool temp_eat;
	public bool eat_forever;
	GameObject player;
	public bool killed = false;
	
	void Start()
	{
		player = GameObject.Find("MainPlayer");
	}
	
	void Update()
	{
		if(!chase && nest.food_num != 0 && !go_eat && !eat_forever && !temp_eat)
		{
			go_eat = true;
		}
		else if(chase)
		{
			transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
			transform.Translate(new Vector3(0, 0, movement_speed * Time.deltaTime));
		}
		else if(!chase && go_eat && !eat_forever && !temp_eat)
		{
			transform.LookAt(new Vector3(nest.transform.position.x, transform.position.y, nest.transform.position.z));
			transform.Translate(new Vector3(0, 0, movement_speed * Time.deltaTime));
		}
		else if(!go_eat && !eat_forever && !temp_eat && !chase)
		{
			if((Vector3.Distance(player.transform.position, transform.position) < detection_range) && Mathf.Abs(player.transform.position.y - transform.position.y) < 1)
			{
				chase = true;
				LevelManager.player_sound_manager.PlayInteraction(player_panic);
			}
		}
		animator.SetBool("eat", temp_eat || eat_forever);
		animator.SetBool("walk", chase || go_eat);
	}
	
	public void PlayWalkSound()
	{
		AudioSource.PlayClipAtPoint(walk_sound, transform.position);
	}
	
	public void PlayEatSound()
	{
		AudioSource.PlayClipAtPoint(eat_sound, transform.position);
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player" && !killed)
		{
			killed = true;
			LevelManager.RestartLevel();
		}
		else if(coll.tag == "Nest")
		{
			go_eat = false;
			if(nest.food_num == 2)
			{
				eat_forever = true;	
			}
			else
			{
				StartCoroutine(EatAWhile());	
			}
		}
	}
	
	IEnumerator EatAWhile()
	{
		temp_eat = true;
		yield return new WaitForSeconds(5.0f);
		temp_eat = false;
		chase = true;
	}
	
}
