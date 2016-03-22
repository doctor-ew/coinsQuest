using UnityEngine;
using System.Collections;

public class Coin_pf : MonoBehaviour {

	private CoinManager coinManager;
	public int coinCount;
	public GameObject coinGameObj;

	public GameObject[] gos;
//	public GUIText guiTimer;
//	private Vector3 pos;

	private float x;
	private float y;
	private float z;

	void Awake () {

		coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();

		gos = new GameObject[coinCount];
		for(int i = 0; i < gos.Length; i++)
		{
			if(i < 3){
				if(i==0) {
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

			GameObject clone = Instantiate(coinGameObj,new Vector3(x,y,z ),Quaternion.identity) as GameObject; 
			clone.name = coinGameObj.name + "_" + i;
			gos[i] = clone;
			coinManager.arrCoins.Add (clone);

			Debug.Log("ppp" + coinManager.arrCoins.Count);
		}
	}

}
