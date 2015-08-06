using UnityEngine;
using System.Collections;

public class ControlerGilhotina : MonoBehaviour, Congelar {
	public Transform topo;
	public Transform bot;
	public bool congelada;
	public int speed;
	public bool subindo;
	public int tempoCongelado;

	// Use this for initialization
	void Start () {
		subindo= false;
		speed = 6;
		congelada = false;
	}
	
	// Update is called once per frame
	void Update () {
		moverGilhotina ();
	}

	public void moverGilhotina() {
		if (congelada == false) {
			if (subindo == true) {
				subir ();
			} else {
				decer ();
			}
			if (this.transform.position.y > topo.position.y) {
				subindo = false;
			}  
			if (this.transform.position.y < bot.position.y) {
				subindo = true;
			}
		} else if(tempoCongelado < 200){
			tempoCongelado++;
		} else {
			tempoCongelado = 0;
			congelada = false;
		}
	}

	public void Congelar() {
		tempoCongelado = 0;
		congelada = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {

	}

	public void subir() {
		transform.Translate ((Vector2.up) * speed * Time.deltaTime);
	}

	public void decer() {
		transform.Translate ((Vector2.up*(-1)) * speed * Time.deltaTime);
	}

}
