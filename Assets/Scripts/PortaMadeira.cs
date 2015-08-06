using UnityEngine;
using System.Collections;

public class PortaMadeira : MonoBehaviour, Queima, Default {
	public GameObject porta;
	public bool queimar;
	public GameObject chama1;
	public GameObject chama2;
	public GameObject chama3;
	public int cont;

	// Use this for initialization
	void Start () {
		queimar = false;
		chama1.SetActive(false);
		chama2.SetActive(false);
		chama3.SetActive(false);
		cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (queimar || cont>50) {
			destroiPorta();
		} else if (queimar) {
			cont++;
		}
	}

	public void destroiPorta() {
		porta.GetComponent<MeshRenderer> ().enabled = false;
		porta.GetComponent<Collider2D> ().isTrigger = true;
		chama1.SetActive(false);
		chama2.SetActive(false);
		chama3.SetActive(false);
		cont = 0;
		queimar = false;
	}

	public void sendDefault() {
		porta.GetComponent<MeshRenderer> ().enabled = true;
		porta.GetComponent<Collider2D> ().isTrigger = false;
		chama1.SetActive(false);
		chama2.SetActive(false);
		chama3.SetActive(false);
		cont = 0;
		queimar = false;
	}

	public void queima() {
		chama1.SetActive(true);
		chama2.SetActive(true);
		chama3.SetActive(true);
		porta.GetComponent<Collider2D> ().isTrigger = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<Player> ().receberDano ();
		}
	}

}
