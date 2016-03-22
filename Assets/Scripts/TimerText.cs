using UnityEngine;
using System.Collections;

public class TimerText : MonoBehaviour {
	// public String[] arrTimes;

	public GUIText guiTimer;

	// Use this for initialization
	void Start () {
		guiTimer = GetComponent<GUIText> ();
		guiTimer.text = "30";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
