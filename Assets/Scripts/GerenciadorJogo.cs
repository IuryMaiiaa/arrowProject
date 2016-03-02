using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {
	public GerenciadorFase faseManager;
	public AudioManager audioController;
	public bool existeboss;
	public GameObject BossDragao;
	public GameObject BossInstanciado;
	public bool bossInvocado;
	public GerenciaMenu GM;


	// Use this for initialization
	void Start () {
		GM = (GerenciaMenu)GameObject.FindObjectOfType (typeof(GerenciaMenu));
		audioController = (AudioManager)GameObject.FindObjectOfType (typeof(AudioManager));
		BossInstanciado = null;
		existeboss = false;
		faseManager = (GerenciadorFase)FindObjectOfType(typeof(GerenciadorFase));
		bossInvocado = false;
		atualizarAudio ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AtualizarGame() {
		faseManager.rotacionarFases();
		if (!existeboss) {
			if (7 < (int)(Random.value * 100) % 10) {
				emitirAlerta ();
				existeboss = true;
			}
		} else if (!bossInvocado) {
			instanciarBoss(Random.Range(1,1));
			bossInvocado=true;
		}
	}

	public void instanciarBoss (int valorBoss) {
		if (valorBoss == 1) {
			BossInstanciado = GameObject.Instantiate(BossDragao) as GameObject;
		}

	}

	public void sendDefault() {
		faseManager.sendDefault();
	}

	public void reiniciar() {
		tirandoSlowTime ();
		Application.LoadLevel(1);
	}

	public void emitirAlerta() {
		audioController.TocarMusicaBoss ();
		Debug.Log("WARNING WARNING WARNING WARNING");
	}

	public void tirandoSlowTime() {
		if(Time.timeScale == 0.3F) {
			Time.timeScale = 1.0F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	public void atualizarAudio() {
		AudioSource[] audios = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
		foreach (AudioSource audio in audios) {
			audio.volume = GM.value;
		}
	}

	public void bossMorto() {
		audioController.TocarMusicaNormal ();
		existeboss = false;
		bossInvocado = false;
	}
}
