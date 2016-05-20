using UnityEngine;
using System.Collections;

public class GerenciaMenu : MonoBehaviour {
	public float value;

	// Use this for initialization
	void Start () {
		value = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit(); 
	}

	public void audioGame(float volume) {
		value = volume;
        //commit meia noite
	}

	public void playGame() {
		DontDestroyOnLoad(this);
		Application.LoadLevel (1);
	}


}
