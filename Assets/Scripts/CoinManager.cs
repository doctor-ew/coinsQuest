using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour {

	public bool chriterion;
	public float chriterionScale;
	public GameObject coin;
	public GameObject daBadAss;

	private GameObject placedCoin;

	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;

	public Sprite[] arrCoinSprites;
	public List<GameObject> arrCoins;
//	public GameObject[] arrCoins;

	public int coinCount;
	public GameObject coinGameObj;
	
	public GameObject[] gos;
	//	public GUIText guiTimer;
	//	private Vector3 pos;
	
	private float x;
	private float y;
	private float z;

	public Sprite bass;


	void Start () {
		arrCoins = new List<GameObject>();

		gos = new GameObject[coinCount];
		for (int i = 0; i < gos.Length; i++) {
			if (i < 3) {
				if (i == 0) {
					x = coinGameObj.gameObject.transform.position.x;
					y = coinGameObj.gameObject.transform.position.y;
					
				} else if (i == 1) {
					x = coinGameObj.gameObject.transform.position.x;
					y = coinGameObj.gameObject.transform.position.y + 4;
					
				} else {
					x = coinGameObj.gameObject.transform.position.x + 4;
					y = coinGameObj.gameObject.transform.position.y + 2;
					
				}
			} else {
				x = coinGameObj.gameObject.transform.position.x + i;
				y = coinGameObj.gameObject.transform.position.y + i;
			}
			
			
			z = coinGameObj.gameObject.transform.position.z;
			
			GameObject clone = Instantiate (coinGameObj, new Vector3 (x, y, z), Quaternion.identity) as GameObject; 
			clone.name = coinGameObj.name + "_" + i;
			gos [i] = clone;
			arrCoins.Add (clone);
			
			Debug.Log ("ppp" + arrCoins.Count);
		}
	}
	
	void Update(){

		mousePosition = Input.mousePosition;
		mousePosition = new Vector3(mousePosition.x,mousePosition.y,8.0F);

		Vector3 pos = mousePosition;
		pos = Camera.main.ScreenToWorldPoint(mousePosition);

		transform.position = Vector2.Lerp (transform.position, mousePosition, moveSpeed);

		if (Input.GetButtonDown ("Fire1")) {

			//			// ////Debug.Log("Shot Fired!" + onCan);
		}		if (Input.GetKey(KeyCode.LeftApple) && !Input.GetKey(KeyCode.LeftControl)) {
			if (Input.GetMouseButtonDown (0)) {
				//Debug.Log ("LA " + pos);
				placedCoin = Instantiate(coin, new Vector3(pos.x,pos.y,1.0F), coin.transform.rotation) as GameObject;
				arrCoins.Add (placedCoin);
				placedCoin.SetActive(true);
				Debug.Log(arrCoins.Count);
			}
		}
		if (Input.GetKey(KeyCode.LeftApple) && Input.GetKey(KeyCode.LeftControl)) {
			if (Input.GetMouseButtonDown (0)) {
				//Debug.Log ("LA+Ctrl");
			}
		}

	}
	void FixedUpdate(){
		
	}
}
