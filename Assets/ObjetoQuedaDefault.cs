using UnityEngine;
using System.Collections;

public class ObjetoQuedaDefault : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sendDefault() {
		Default []objetos = this.gameObject.GetComponentsInChildren<Default> ();
		Debug.Log (objetos.Length + "gerencia");
		//for(int Cont=0; Cont<objetos.Length;Cont++) {
		//	objetos[Cont].sendDefault();
		//}
	}
}
