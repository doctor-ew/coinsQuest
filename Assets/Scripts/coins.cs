using UnityEngine;
using System.Collections;

public class coins : MonoBehaviour
{
	
	
	public CoinManager coinManager;
	public int spriteIndex;
	public float yPos;
	public GameObject gos;
	public GameObject coinObj;
	public SpriteRenderer currentCoinSprite;
	public Vector3 screenPoint;
	public Vector3 offset;
	
	public bool clicked = false;
	public RaycastHit hit;
	
	public Sprite[] arrCoinSprites;
	
//	public bool chriterion;
//	public float chriterionScale;
//	public Sprite[] coinManager.arrCoinSprites;
	
	void Awake ()
	{
		gos = GameObject.Find ("CoinManager");
		coinManager = gos.GetComponent<CoinManager> ();

		coinObj = gameObject;
		currentCoinSprite = gameObject.GetComponent<SpriteRenderer> ();

	}

	void Start ()
	{


		arrCoinSprites = coinManager.arrCoinSprites;

		spriteIndex = 0;
		if (coinManager.chriterion) {
			//Debug.Log("chr " + coinManager.chriterionScale + " :: " + gameObject.transform.localScale);
			float lsX = gameObject.transform.localScale.x * coinManager.chriterionScale;
			float lsY = gameObject.transform.localScale.y * coinManager.chriterionScale;
			float lsZ = gameObject.transform.localScale.z;
			
			gameObject.transform.localScale = new Vector3 (lsX, lsY, lsZ);
		}
	}
	
	void OnMouseDown ()
	{
		if (Input.GetMouseButtonDown (1)) {
			//Debug.Log ("RC " + hit);
		}
		Vector3 scanPos = gameObject.transform.position;
		screenPoint = Camera.main.WorldToScreenPoint (scanPos);
		offset = scanPos - Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	
	void OnMouseDrag ()
	{
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		
		
		transform.position = curPosition;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			OnRightClick ();
		}

	}

	void OnRightClick ()
	{
		// Cast a ray from the mouse
		// cursors position
		Ray clickPoint = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitPoint;
		
		// See if the ray collided with an object
		if (Physics.Raycast (clickPoint, out hitPoint)) {
			// Make sure this object was the
			// one that received the right-click
			if (hitPoint.collider == this.GetComponent<Collider> ()) {
				// Put code for the right click event
				//Debug.Log("Right Clicked on " + this.name);
				IterateCoinSpriteArray ();
			}
		}
	}
	void IterateCoinSpriteArray ()
	{
		spriteIndex += 1;
		if (spriteIndex == coinManager.arrCoinSprites.Length) {
			spriteIndex = 0;
		}

		UpdateCoinSprite (spriteIndex);

	}
	void UpdateCoinSprite (int spriteIndex)
	{
		currentCoinSprite = this.GetComponent<SpriteRenderer> ();
		
		currentCoinSprite.sprite = coinManager.arrCoinSprites [spriteIndex];
		//Debug.Log ("Changing Coin " + spriteIndex + " :: " + coinManager.arrCoinSprites.Length);

	}
}
