using UnityEngine;
using System.Collections;

public class DebugAndroid : MonoBehaviour {
    public UnityEngine.UI.Text debug;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void log(string log)
    {
        debug.text = log;
    }
}
