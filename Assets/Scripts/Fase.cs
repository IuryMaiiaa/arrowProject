using UnityEngine;
using System.Collections;

public class Fase : MonoBehaviour {
	public GameObject inicio;
	public GameObject fim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 posInit() {
		//Debug.Log (gameObject.transform.position.x + " + " + inicio.transform.position.x);
		return inicio.transform.position;
		/*return new Vector3(gameObject.transform.position.x+inicio.transform.position.x,
		                   gameObject.transform.position.y+inicio.transform.position.y,
		                   gameObject.gameObject.transform.position.z);
	*/
	}

	public Vector3 posFim() {
		return fim.transform.position;
		/*return new Vector3(gameObject.transform.position.x+fim.transform.position.x,
		                   gameObject.transform.position.y+fim.transform.position.y,
		                   gameObject.gameObject.transform.position.z);
	*/
	}
}
