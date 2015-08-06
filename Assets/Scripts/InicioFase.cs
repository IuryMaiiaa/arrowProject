using UnityEngine;
using System.Collections;

public class InicioFase : MonoBehaviour {
	public GerenciadorJogo gameManager;
	// Use this for initialization
	void Start () {
		gameManager = (GerenciadorJogo)FindObjectOfType(typeof(GerenciadorJogo));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerExit2D(Collider2D coll) {
		if(coll.gameObject.tag.Equals("Player")) {
			gameManager.AtualizarGame();
		}
	
	}
}
