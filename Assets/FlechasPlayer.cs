using UnityEngine;
using System.Collections;

public class FlechasPlayer : MonoBehaviour {
	public Player player;
	public UnityEngine.UI.Text text;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "X" + player.quantidadeFlechas;
	}
}
