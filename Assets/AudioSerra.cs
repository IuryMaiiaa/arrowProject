using UnityEngine;
using System.Collections;

public class AudioSerra : MonoBehaviour {
	public AudioClip SawAudio;
	public AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			audioSource.clip = SawAudio;
			audioSource.Play();
		}
	}
}
