using UnityEngine;
using System.Collections;
using System;

public class PlayerSoundManager : MonoBehaviour {
	
	public bool busy;
	
	public AudioSource audio_source;
	
	public AudioClip[] hummings;
	
	public void PlayInteraction(AudioClip sound)
	{
		StartCoroutine(PlayInteractionIE(sound));
	}
	
	IEnumerator PlayInteractionIE(AudioClip sound)
	{
		busy = true;
		audio_source.Stop();
		audio_source.clip = sound;
		audio_source.PlayOneShot(sound);
		yield return new WaitForSeconds(sound.length);
		busy = false;
	}
	
	IEnumerator PlayHummingIE(AudioClip sound)
	{
		busy = true;
		audio_source.Stop();
		audio_source.clip = sound;
		audio_source.PlayOneShot(sound);
		yield return new WaitForSeconds(sound.length + 5.0f);
		busy = false;
	}
	
	void Update()
	{
		/*
		if(!busy)	
		{
			StartCoroutine(PlayHummingIE(hummings[UnityEngine.Random.Range(0, hummings.GetLength(0))]));
		}
		*/
	}
	
}
