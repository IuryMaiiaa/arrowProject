using UnityEngine;
using System.Collections;

public class DragãoBoss : MonoBehaviour, Congelar {
	public bool bossMorto;
	public float tempoMorte;
	public bool subindo;
	public bool congelado;
	public bool invunerabilidade;
	public Transform pontobaixo;
	public Transform pontocima;
	public Player Player;
	public bool fragilizado;
	public float timeIvunerabilidade;
	public GameObject bolaDeFogo;
	private Animator controleAnimacao;
	private float timeUltimaBolaDeFogo;
	public bool fase1;
	public bool fase2;
	public GerenciadorJogo gerenciaJogo;

	// Use this for initialization
	void Start () {
		bossMorto = false;
		subindo = true;
		gerenciaJogo = (GerenciadorJogo)GameObject.FindObjectOfType (typeof(GerenciadorJogo));
		controleAnimacao = this.gameObject.GetComponent<Animator> ();
		invunerabilidade = false;
		timeUltimaBolaDeFogo = Time.time;
		congelado = false;
		fase1 = true;
		Player = (Player)GameObject.FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		if(fase1) {
			this.transform.position = new Vector3(Player.gameObject.transform.position.x+22f,this.transform.position.y,this.transform.position.z);
			if(Time.time > timeUltimaBolaDeFogo+2.5f) {
				AtkBolaDeFogoForte();
				timeUltimaBolaDeFogo = Time.time;
			}
			moverBossFase1();
		}	else if (fase2) {

		}
		if (Time.time > timeIvunerabilidade + 2f) {
			invunerabilidade = false;
		}

		if(bossMorto && Time.time>tempoMorte+3f) {
			Destroy(this.gameObject);
		}
	}

	public void moverBossFase1() {
		if (subindo == true) {
			subir ();
		} else {
			decer ();
		}
		if (this.transform.position.y > pontocima.position.y) {
			subindo = false;
		}  
		if (this.transform.position.y < pontobaixo.position.y) {
			subindo = true;
		}
	}

	public void Congelar() {
		if (!invunerabilidade) {
			fragilizado = true;
		}
	}

	public void AtkBolaDeFogoForte() {
		GameObject BoladeFogo = GameObject.Instantiate(bolaDeFogo) as GameObject;
		BoladeFogo.GetComponent<Transform> ().position = this.transform.position;
	}

	public void flechaDano() {
		if( fase1 && fragilizado ) {
			fragilizado = false;
			fase2 = true;
			fase1 = false;
			invunerabilidade = true;
			timeIvunerabilidade = Time.time;
			controleAnimacao.SetBool("fase1",false);
		} else if ( fase2 && fragilizado ) {
			morte();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
	}


	
	public void subir() {
		transform.Translate ((Vector2.up) * 2f * Time.deltaTime);
	}
	
	public void decer() {
		transform.Translate ((Vector2.up*(-1)) * 2f * Time.deltaTime);
	}

	public void morte() {
		bossMorto = true;
		this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		controleAnimacao.SetBool ("morte", true);
		tempoMorte = Time.time;
		gerenciaJogo.bossMorto();
	}

}
