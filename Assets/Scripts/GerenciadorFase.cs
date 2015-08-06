using UnityEngine;
using System.Collections;

public class GerenciadorFase : MonoBehaviour {
	private Fase atual;
	private Fase anterior;
	private Fase proxima;
	public GameObject pontoEncontro;
	public GameObject pontoInicio;
	private ArrayList Fases;


	// Use this for initialization
	void Start () {
		Fases = new ArrayList();
		//coletando todas as fases disponiveis no jogo para poder gerar o games
		//Aleatoriamente depois;
		if (Fases.Count == 0) {
			GameObject[] auxFases;
			auxFases = GameObject.FindGameObjectsWithTag("Fase");
			foreach(GameObject fase in auxFases) {
				if (fase.gameObject.GetComponent("Fase") as Fase) {
					Fases.Add((Fase)fase.gameObject.GetComponent("Fase"));
				}
			}
		}
		//verificaçao parara um caso hipotetico de que nao entre no primeiro laço
		if(Fases != null) {
			//Loop para mover todas as fases apra o ponto de encontro
			foreach(Fase fase in Fases) {
				EnviarPontoEncontro(fase);
			}
		}
		//Irei rotacionar as fases pela primeira vez, para adicionar uma ao ponto inicial para poder começar o jogo
		iniciarJogo();



	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Fases.Count+ " " + fase.posInit());
	}

	//meus metodos D:

	void EnviarPontoEncontro(Fase fase) {
		fase.transform.position = pontoEncontro.transform.position;
	}

	public void sendDefault() {
		Default []objetos = anterior.GetComponentsInChildren<Default> ();
		Debug.Log (objetos.Length);
		for(int Cont=0; Cont<objetos.Length;Cont++) {
			objetos[Cont].sendDefault();
		}
	}

	//gira as fases apra criar um loop de fases;
	public void rotacionarFases() {
		if (anterior == null) {
			anterior = atual;
			atual = proxima;
			proxima = puxarNovaFase ();
			posicionarFase (proxima, atual.posFim ());
		} else {
			armazenarFase ();
			anterior = atual;
			atual = proxima;
			proxima = puxarNovaFase ();
			posicionarFase (proxima, atual.posFim ());
		}
	}

	//pega uma fase do jogo e adicona novamente no arry.
	private void armazenarFase() {
		EnviarPontoEncontro (anterior);
		Fases.Add(anterior);
	}

	//pega um fase do arry e remove ela do mesmo.
	private Fase puxarNovaFase() {
		int selecionada = (int)(Random.value*100)%Fases.Count;
		Fase faseSelecionada = (Fase)Fases[selecionada];
		Fases.RemoveAt(selecionada);
		return faseSelecionada;
	}

	//adiciona as condiçoes para comecar a rotacionar as fases em loop infinito.
	private void iniciarJogo() {
		Fase aux = puxarNovaFase();
		posicionarFase (aux, pontoInicio.transform.position);
		atual = aux;
		aux = puxarNovaFase();
		posicionarFase(aux,atual.posFim());
		proxima = aux;
	}

	private void posicionarFase(Fase fase,Vector3 pos) {
		float diferencaX;
		float diferencaY;
		if (fase.posInit().x > pos.x) {
			diferencaX = fase.posInit().x - pos.x;
			fase.transform.position = new Vector3 (fase.transform.position.x + diferencaX,
			                                       fase.transform.position.y,
			                                       fase.transform.position.z);
		} else {
			diferencaX = pos.x - fase.posInit().x;
			fase.transform.position = new Vector3 (fase.transform.position.x + diferencaX,
			                                       fase.transform.position.y,
			                                       fase.transform.position.z);
		}
		if (fase.posInit().y > pos.y) {
			diferencaY = fase.posInit().y - pos.y;
			fase.transform.position = new Vector3 (fase.transform.position.x,
			                                       fase.transform.position.y + diferencaY,
			                                       fase.transform.position.z);
		} else {
			diferencaY = pos.y - fase.posInit().y;
			fase.transform.position = new Vector3 (fase.transform.position.x,
			                                       fase.transform.position.y + diferencaY,
			                                       fase.transform.position.z);
		}
	}
}
