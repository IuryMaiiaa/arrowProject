using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioClip MusicaRelachante;
	public AudioClip OasisRelachante;
	public AudioClip bossDragonMusic;
	private AudioClip musicaDaVez;
	public AudioSource audioSource;
	public GerenciadorJogo gameGerencia;

	// Use this for initialization
	void Start () {
		musicaDaVez = MusicaRelachante;
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			audioSource.clip = musicaDaVez;
			audioSource.Play();
		} 
	}

	public void TocarMusicaNormal() {
		audioSource.Stop ();
		audioSource.clip = MusicaRelachante;
		audioSource.Play ();
		Debug.Log ("musica normal");
		musicaDaVez = MusicaRelachante;
	}

	public void TocarMusicaBoss() {
		audioSource.Stop ();
		audioSource.clip = bossDragonMusic;
		audioSource.Play ();
		musicaDaVez = bossDragonMusic;
	}
}
