using UnityEngine;
using System.Collections;

public class FlechaScript : MonoBehaviour {
	private float tempoInicial;
	private bool autoDestruicao;
	// Use this for initialization
	void Start () {
		autoDestruicao = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(autoDestruicao && Time.time > 0.3f+tempoInicial) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		this.GetComponent<Collider2D> ().isTrigger = false;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
		} else {
			autoDestruicao = true;
			tempoInicial = Time.time;
		}
	}

}
