using UnityEngine;
using System.Collections;

public class MonitorarAudio : MonoBehaviour {

	public UnityEngine.UI.Slider slider;
	public GerenciaMenu GM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AtualizarVolume() {
		GM.audioGame (slider.value);
	}


}
