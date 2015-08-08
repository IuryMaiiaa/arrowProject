using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {
	public GerenciadorFase faseManager;
	public bool existeboss;
	public GameObject BossDragao;
	public GameObject BossInstanciado;
	public bool bossInvocado;


	// Use this for initialization
	void Start () {
		BossInstanciado = null;
		existeboss = false;
		faseManager = (GerenciadorFase)FindObjectOfType(typeof(GerenciadorFase));
		bossInvocado = false;
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
		Application.LoadLevel(0);
	}

	public void emitirAlerta() {
		Debug.Log("WARNING WARNING WARNING WARNING");
	}

	public void bossMorto() {
		existeboss = false;
		bossInvocado = false;
	}
}
