using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class CountDown : MonoBehaviour
{

	public bool finalCountDown = false;
	public bool userHasHitReturn = false;
	public bool ticktock = true;
	public float timeLeft;
	public GUIText gt1;
	public int timeIndex;
	public RaycastHit hit;
	public Vector3 pos;


	public GUI gu;
	public GUIText gt0;
	public string counterText;
	public string stringToEdit;
	public string[] arrTime;

	void Start ()
	{
		timeIndex = 0;

		pos = Camera.main.WorldToScreenPoint (transform.position);
		pos.x = pos.x / Screen.width;
		pos.y = (pos.y / Screen.height) + 0.010f;


		gt1 = GUIText.Instantiate (gt0, pos, Quaternion.identity) as GUIText;

		stringToEdit = arrTime [timeIndex];
		Debug.Log ("|-o-| " + gameObject.name + "pos " + pos + " tf: " + transform.position);
	}
	
	void OnMouseDown ()
	{
		finalCountDown = false;
		userHasHitReturn = false;
		timeIndex += 1;
		if (timeIndex == arrTime.Length) {
			timeIndex = 0;
		}
		gt1.text = arrTime [timeIndex];
		stringToEdit = gt1.text;
		Debug.Log ("$$$ " + arrTime [timeIndex]);
	}
	/*
	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			OnRightClick ();
			//Debug.Log("click");
		}

	}
	*/
	void FixedUpdate ()
	{
		if (Input.GetKeyDown ("space")) {

			//finalCountDown = true;
			
			timeLeft = ParseStrToFloat (stringToEdit);
			userHasHitReturn = true;
		}


		if (userHasHitReturn && !finalCountDown) {
			finalCountDown = true;
		}

		if (finalCountDown) {
		

			if (timeLeft <= 0.0f) {
				userHasHitReturn = false;
				finalCountDown = false;
			} else {
				counterText = ParseIntToStr ((int)timeLeft);
				gt1.text = counterText;
			}
			timeLeft -= Time.deltaTime;

		}

	}
/*
	void OnRightClick()
	{
		// Cast a ray from the mouse
		// cursors position
		Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitPoint;
		
		// See if the ray collided with an object
		if (Physics.Raycast(clickPoint, out hitPoint))
		{
			// Make sure this object was the
			// one that received the right-click
			if (hitPoint.collider == this.GetComponent<Collider>())
			{
				// Put code for the right click event
				Debug.Log("Right Clicked on " + this.name);
				//IterateCoinSpriteArray();
			}
		}
	}

*/
	public float ParseStrToFloat (string value)
	{
		float converted = float.Parse (value);
		return converted;
	}
	public int ParseFloatToInt (float value)
	{
		int converted = (int)value;
		return converted;
	}
	public int ParseStrToInt (string value)
	{
		int converted = int.Parse (value);
		return converted;
	}
	public string ParseFloatToStr (float value)
	{
		string converted = value.ToString ("00");
		return converted;
	}
	public string ParseIntToStr (int value)
	{
		string converted = value.ToString ("00");
		return converted;
	}
}
