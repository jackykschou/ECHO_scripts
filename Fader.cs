using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	
	public float fade_speed;
	public GUITexture fade_effect;
	public AudioClip fade_sound;
	
	public void FadeIn()
	{
		StartCoroutine(FadeInHelper());
	}
	
	IEnumerator FadeInHelper()
	{
		AudioSource.PlayClipAtPoint(fade_sound, transform.position);
		Color texture_color = fade_effect.color;
		while(texture_color.a < 1.0f)
		{
			texture_color.a -= fade_speed;
			fade_effect.color = texture_color;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		fade_effect.color = texture_color;
	}
	
	public void FadeOut()
	{
		StartCoroutine(FadeOutHelper());
	}
	
	IEnumerator FadeOutHelper()
	{
		AudioSource.PlayClipAtPoint(fade_sound, transform.position);
		Color texture_color = fade_effect.color;
		while(texture_color.a > 0f)
		{
			texture_color.a += fade_speed;
			fade_effect.color = texture_color;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		fade_effect.color = texture_color;
	}
}
