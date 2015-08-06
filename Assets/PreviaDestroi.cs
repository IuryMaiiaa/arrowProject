using UnityEngine;
using System.Collections;

public class PreviaDestroi : MonoBehaviour {
	public float cont;
	// Use this for initialization

	void Start () {
		cont = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > cont + 0.7f) {
			Destroy(this.gameObject);
		}
	}
}
