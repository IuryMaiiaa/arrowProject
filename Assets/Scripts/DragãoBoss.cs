using UnityEngine;
using System.Collections;

public class DragãoBoss : MonoBehaviour, Congelar {
	public bool congelado;
	public bool invunerabilidade;
	public Player Player;
	public bool fragilizado;
	public float timeIvunerabilidade;
	public GameObject bolaDeFogo;
	private Animator controleAnimacao;
	private float timeUltimaBolaDeFogo;
	public bool fase1;
	public bool fase2;

	// Use this for initialization
	void Start () {
		invunerabilidade = false;
		timeUltimaBolaDeFogo = Time.time;
		congelado = false;
		fase1 = true;
		Player = (Player)GameObject.FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		if(fase1) {
			this.transform.position = new Vector3(Player.gameObject.transform.position.x+22f,0,0);
			if(Time.time > timeUltimaBolaDeFogo+3f) {
				AtkBolaDeFogoForte();
				timeUltimaBolaDeFogo = Time.time;
			}
		}	else if (fase2) {

		}
		if (Time.time > timeIvunerabilidade + 2f) {
			invunerabilidade = false;
		}
	}
	public void Congelar() {
		if (invunerabilidade) {
			fragilizado = true;
		}
	}

	public void AtkBolaDeFogoForte() {
		GameObject BoladeFogo = GameObject.Instantiate(bolaDeFogo) as GameObject;
		BoladeFogo.GetComponent<Transform> ().position = this.transform.position;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Flecha") {
			if( fase1 && fragilizado ) {
				fragilizado = false;
				fase2 = true;
				controleAnimacao.SetBool("fase1",false);
				fase1 = false;
				invunerabilidade = true;
				timeIvunerabilidade = Time.time;
			}
		} else {
		}
	}




}
