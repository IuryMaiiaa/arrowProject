using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Speed;
	public bool pulando;
	public GameObject Flecha;
	public GameObject FlechaGelo;
	public GameObject FlechaFogo;
	private float anguloY;
	private float anguloX;
	private float forcaPulo;
	private int valorFlecha;
	public int pontuacao;
	public GameObject FlechaEscolhida;
	public int vida;
	public GameObject prefPreviaTragetoria;
	public float timeUltimoDisparo;

	// Use this for initialization
	void Start () {
		timeUltimoDisparo = Time.time;
		FlechaEscolhida = Flecha;
		pontuacao = 500;
		pulando = true;
		anguloY = 500;
		anguloX = 1000;
		forcaPulo = 40;
		vida = 3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * Speed * Time.deltaTime);
		if (vida == 0 ) {
			fimJogo();
		}
		if(Time.time>0.3f+timeUltimoDisparo) {
			atkPrevia();
			timeUltimoDisparo = Time.time;
		}
	}

	public void jump() {
		if (!pulando) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 10 * forcaPulo);
			pulando = true;
		}
	}

	public void atkPrevia() {
		GameObject flechaPrevia = GameObject.Instantiate(prefPreviaTragetoria) as GameObject;
		flechaPrevia.GetComponent<Transform> ().position = this.transform.position;
		flechaPrevia.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
	}

	public void atk() {
		GameObject flecha = GameObject.Instantiate(FlechaEscolhida) as GameObject;
		flecha.GetComponent<Transform> ().position = this.transform.position;
		flecha.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
		flecha.GetComponent<Collider2D> ().isTrigger = true;
		pontuacao = pontuacao - valorFlecha;
	}

	public void UpAngulo() {
		anguloY += 100;
	}

	public void DonwAngulo() {
		anguloY -= 100;
	}

	public void SlowTime() {
		if (Time.timeScale == 1.0F) {
			Time.timeScale = 0.3F;
			anguloX = anguloX * 3.3F;
			anguloY = anguloY * 3.3F;
			forcaPulo = forcaPulo * 3.2F;
		} else {
			Time.timeScale = 1.0F;
			anguloX = anguloX / 3.3F;
			anguloY = anguloY / 3.3F;
			forcaPulo = forcaPulo / 3.2F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "terreno") {
			pulando=false;
		}
		if (collision.gameObject.tag == "guilhotina") {
			fimJogo();
		}
	}

	public void MudarTipoFlecha(int valor) {
		if( valor == 1) {
			FlechaEscolhida = Flecha;
			valorFlecha = 1;
		}
		if (valor == 2) {
			FlechaEscolhida = FlechaGelo;
			valorFlecha = 3;
		}
		if (valor == 3) {
			FlechaEscolhida = FlechaFogo;
			valorFlecha = 5;
		}
	}

	public void receberDano() {
		vida = vida - 1;
	}

	public void incrementarFlechas () {
		pontuacao = pontuacao + 10;
	}

	public void incrementarVidas () {
		vida = vida + 1;
	}

	public void fimJogo() {
		GameObject.Destroy(this.gameObject);
	}
}
