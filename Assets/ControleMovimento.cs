using UnityEngine;
using System.Collections;

public class ControleMovimento : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movimentacao ();
	}

	void Movimentacao() {
		if (Input.GetAxisRaw ("Horizontal") > 0) {
						animator.SetBool ("andar", true);
		}
		if (Input.GetAxisRaw("Horizontal") < 0) {
			animator.SetBool( "andar",false );
		}
	}
}
