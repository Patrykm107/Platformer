using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
	public void changeBackgroundVolume(float value)
	{
		FindObjectOfType<AudioManager>().audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(value) * 20);
	}
}
