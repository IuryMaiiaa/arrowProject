using UnityEngine;
using System.Collections;

public class FlechaGelo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		collision.gameObject.GetComponent<Congelar> ().Congelar ();
	}
}
