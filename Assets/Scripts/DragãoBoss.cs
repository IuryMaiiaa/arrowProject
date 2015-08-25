using UnityEngine;
using System.Collections;

public class DragãoBoss : MonoBehaviour, Congelar {
	private bool dragaoMovido;
	private int ContVidaTorrentFogo;
	private float tempoInvunerabilidade;
	private int contVidaFase1;
	public int contVidaFase2;
	private bool bossMorto;
	private float tempoMorte;
	private bool subindo;
	private bool congelado;
	public bool invunerabilidade;
	public Transform pontobaixo;
	public Transform pontocima;
	public Player Player;
	public bool fragilizado;
	private float timeIvunerabilidade;
	public GameObject bolaDeFogo;
	private Animator controleAnimacao;
	private float timeUltimaBolaDeFogo;
	public bool fase1;
	public bool fase2;
	public GerenciadorJogo gerenciaJogo;

	// Use this for initialization
	void Start () {
		dragaoMovido = false;
		ContVidaTorrentFogo = 0;
		contVidaFase1 = 0;
		contVidaFase2 = 0;
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
			if(contVidaFase2>=3 && !bossMorto) {
				morte();
			}
			moverBossFase2();
		}
		if (Time.time > timeIvunerabilidade + tempoInvunerabilidade) {
			invunerabilidade = false;
			if (fase2 && this.gameObject.GetComponent<Collider2D>().isTrigger) {
				dragaoDesCongelado();
				dragaoMovido = false;
			}
		}

		if(bossMorto && Time.time>tempoMorte+1.3f) {
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

	public void moverBossFase2() {
		if(!dragaoMovido) {
			this.transform.position = new Vector3(Player.gameObject.transform.position.x+30f,pontocima.position.y,this.transform.position.z);
			dragaoMovido = true;
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
			invunerabilidade = true;
			contVidaFase1++;
			timeIvunerabilidade = Time.time;
			tempoInvunerabilidade = 0.5f;
			if (contVidaFase1>=4) {
				timeIvunerabilidade = Time.time;
				tempoInvunerabilidade = 1f;
				fase1 = false;
				fase2 = true;
				controleAnimacao.SetBool("fase1",false);
			}
		} else if ( fase2 && fragilizado ) {
			fragilizado = false;
			invunerabilidade = true;
			ContVidaTorrentFogo++;
			timeIvunerabilidade = Time.time;
			tempoInvunerabilidade = 0.1f;
			if (ContVidaTorrentFogo>=4) {
				ContVidaTorrentFogo=0;
				contVidaFase2++;
				timeIvunerabilidade = Time.time;
				tempoInvunerabilidade = 2f;
				dragaoCongelado();
			}
		}
	}

	public void dragaoCongelado() {
		this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		controleAnimacao.SetBool("congelado",true);
	}

	public void dragaoDesCongelado() {
		this.gameObject.GetComponent<Collider2D> ().isTrigger = false;
		controleAnimacao.SetBool("congelado",false);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "player") {
			dragaoCongelado();
			coll.gameObject.GetComponent<Player>().fimJogo();
		}
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
