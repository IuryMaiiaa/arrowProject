using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {
	public GerenciadorFase faseManager;

	// Use this for initialization
	void Start () {
		faseManager = (GerenciadorFase)FindObjectOfType(typeof(GerenciadorFase));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AtualizarGame() {
		faseManager.rotacionarFases();
	}

	public void sendDefault() {
		faseManager.sendDefault();
	}

	public void reiniciar() {
		Application.LoadLevel(0);
	}
}
