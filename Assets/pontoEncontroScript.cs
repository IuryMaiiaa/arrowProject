using UnityEngine;
using System.Collections;

public class pontoEncontroScript : MonoBehaviour {
	public Player player;

	// Use this for initialization
	void Start () {
		player = (Player)GameObject.FindObjectOfType (typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
