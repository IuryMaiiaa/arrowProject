using UnityEngine;
using System.Collections;

public class BolaDeFogoDragao : MonoBehaviour, Congelar {
	public float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.eulerAngles = new Vector3 (0f+this.transform.eulerAngles.x, 0f+this.transform.eulerAngles.y, -2f+this.transform.eulerAngles.z);
		if(Time.time > time+5f) {
			Destroy(this.gameObject);
		}
	}

	public void Congelar() {
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<Player>().receberDano();
			Destroy(this.gameObject);
		}
	}
}
