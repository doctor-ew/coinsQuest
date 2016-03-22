

using UnityEngine;
using System.Collections;

public class DaBadassManager : MonoBehaviour
{
	
	
	
	public CountDown countdown;
	public GameObject gocd;

	public TimeCoinController timeCoinCont;

	
	private CoinManager coinManager;
	private float lsX, lsY, lsZ;
	private GameObject gos;
	private GameObject rando;
	
	public Animator dabanir;
	public Animator dbanir;
	public Animator dswanir;
	public Animator dtcanir;

	public AudioSource swapSound;

	public AudioClip swapMoving;
	public AudioClip swapLanded;
	public AudioClip tickTock;

	public bool activateDaAdBass = false;
	public bool activateDaBadAss = false;
	public bool activateDaFishingPole = false;
	public bool activateDaHalfOff = false;
	public bool activateDaSwappo = false;
	public bool activateDaManyFaces = false;
	public bool activateDaTimeyWimey = false;



	public bool animateDaAdBass = false;
	public bool animateDaBadAss = false;
	public bool animateFishingPole = false;
	public bool animateDaSwappo = false;
	public bool animateDaManyFaces = false;
	public bool animateDaTimeyWimey = false;

	public bool daAdBassActivated = false;
	public bool daAdBassAnimated = false;

	public bool daBadAssActivated = false;
	public bool daBadAssAnimated = false;
	
	public bool daFishingPoleActivated = false;
	public bool daFishingPoleAnimated = false;
	
	public bool daHalfOffActivated = false;
	public bool daHalfOffAnimated = false;
	
	public bool daSwappoActivated = false;
	public bool daSwappoAnimated = false;

	public bool daManyFacesActivated = false;
	public bool daManyFacesAnimated = false;

	public bool daTimeyWimeyActivated = false;
	public bool daTimeyWimeyAnimated = false;

	public bool showThlump = false;
	public bool iterateTimeCoin = false;

	public bool timeFwd = false;

	public Camera camera;
	
	public Color color1 = Color.red;
	public Color color2 = Color.green;
	public Color color3 = Color.green;
	
	public float duration = 2.5F;
	public float max_x;
	public float min_x;
	public float max_y;
	public float min_y;
/*
	public float max_x = 17.0f;
	public float min_x = 5.0f;
	public float max_y = 9.0f;
	public float min_y = 1.0f;
*/
	public float randoroo = 0;
	
	public GameObject daAdBass;
	public GameObject daBadAss;
	public GameObject daFishingPole;
	public GameObject daHalfOff;
	public GameObject daSwappo;
	public GameObject daTimeyWimey;
	public GameObject thlumpCoin;
	public GameObject[] arrDaBadAss;

	public GameObject timeyWimeyCoin ;
	public GameObject manyFacesCoin ;

	public int countSwappo = 0;
	public int whichCoinIndex;
	public int countTimeyCoin = 0;

	public Sprite badAssSprite;
	public Sprite[] clockSprite;
	public Sprite swappoSprite;

	public Sprite[] swappoFish;
	
	public SpriteRenderer dabsr;
	public SpriteRenderer dbasr;
	public SpriteRenderer dswsr;
	public SpriteRenderer dtcsr;

	public string[] anim_names = {"daBadass_p25","daBadass_p10","daBadass_m10"};			
	
	public string whichCoin;
	void Awake ()
	{
		camera = GetComponent<Camera> ();
		camera.clearFlags = CameraClearFlags.SolidColor;
		
		daFishingPole.SetActive (false);

		daTimeyWimey = GameObject.Find ("daTimeCoin");
		daHalfOff = GameObject.Find ("daHalfOff");

		timeCoinCont = daTimeyWimey.GetComponent<TimeCoinController> ();
		daSwappo = GameObject.Find ("daSwappoCoin");
		daAdBass = GameObject.Find ("daAdBassCoin");
		daBadAss = GenerateRandomBadAss ();
		
		dbasr = daBadAss.GetComponent<SpriteRenderer> ();
		badAssSprite = dbasr.sprite;
		dbanir = daBadAss.GetComponent<Animator> ();
		swapSound = GetComponent<AudioSource> ();
		
		// dtcanir = daTimeyWimey.GetComponent<Animator> ();

		// Debug.Log ("v.011");
	}
	
	
	void Start ()
	{
		gos = GameObject.Find ("CoinManager");
		coinManager = gos.GetComponent<CoinManager> ();
		countdown = gocd.GetComponent<CountDown> ();

		if (coinManager.chriterion) {

			lsX = daAdBass.transform.localScale.x * coinManager.chriterionScale;
			lsY = daAdBass.transform.localScale.y * coinManager.chriterionScale;
			lsZ = daAdBass.transform.localScale.z;
			daAdBass.transform.localScale = new Vector3 (lsX, lsY, lsZ);

			lsX = daSwappo.transform.localScale.x * coinManager.chriterionScale;
			lsY = daSwappo.transform.localScale.y * coinManager.chriterionScale;
			lsZ = daSwappo.transform.localScale.z;
			daSwappo.transform.localScale = new Vector3 (lsX, lsY, lsZ);
			
			lsX = daTimeyWimey.transform.localScale.x * coinManager.chriterionScale;
			lsY = daTimeyWimey.transform.localScale.y * coinManager.chriterionScale;
			lsZ = daTimeyWimey.transform.localScale.z;
			daTimeyWimey.transform.localScale = new Vector3 (lsX, lsY, lsZ);
			

			for (int x = 0; x< arrDaBadAss.Length; x++) {
				GameObject dba = arrDaBadAss [x];
				lsX = dba.transform.localScale.x * coinManager.chriterionScale;
				lsY = dba.transform.localScale.y * coinManager.chriterionScale;
				lsZ = dba.transform.localScale.z;
				dba.transform.localScale = new Vector3 (lsX, lsY, lsZ);
			}

		}
		//GetBadAssCoin ();
	}

	void Update ()
	{
		if (timeCoinCont.timeFU) {
			//if (dtcanir.GetBool ("b_time_done")) {
			//if (animateDaTimeyWimey && timeCoinCont.timeCoinIntroComplete) {
			dtcanir.enabled = false;
			if (timeFwd) {
				GameObject.Find ("daTimeCoin").GetComponent<SpriteRenderer> ().sprite = clockSprite [1];
			} else {
				GameObject.Find ("daTimeCoin").GetComponent<SpriteRenderer> ().sprite = clockSprite [2];
			}


		}


		if (Input.GetKeyUp (KeyCode.A) && !activateDaAdBass && !daAdBassActivated) {
			
			GetAdBassCoin ();			
			
			activateDaAdBass = true;
			
		}
		
		if (Input.GetKeyUp (KeyCode.B) && !activateDaBadAss && !daBadAssActivated) {
			GetBadAssCoin (null);			
			
			activateDaBadAss = true;
		}
		
		if (Input.GetKeyUp (KeyCode.C) && !activateDaManyFaces && !daManyFacesActivated) {
			activateDaManyFaces = true;
			iterateTimeCoin = true;
			
			// Debug.Log ("|-oo-| ManyFaces!" + activateDaManyFaces + " :: " + daManyFacesActivated + " ::: ");
		}
		
		if (Input.GetKeyUp (KeyCode.F) && !activateDaFishingPole && !daFishingPoleActivated) {

			daFishingPole.SetActive (true);
			daFishingPole.transform.position = new Vector3 (Random.Range (1.0f, 9.0f), daFishingPole.transform.position.y, daFishingPole.transform.position.z);
			StartCoroutine (GoFish (1.5f));
		}
		if (Input.GetKeyUp (KeyCode.H) && !activateDaFishingPole && !daFishingPoleActivated) {
			
			daHalfOff.SetActive (true);
			activateDaHalfOff = true;
			StartCoroutine (OffHalfOff (5f));
//			daHalfOff.transform.position = new Vector3 (Random.Range (1.0f, 9.0f), daHalfOff.transform.position.y, daHalfOff.transform.position.z);
//			StartCoroutine (HalfOff (1.5f));
		}

		if (Input.GetKeyUp (KeyCode.S) && !activateDaSwappo && !daSwappoActivated) {
			
			for (int t = 0; t < swappoFish.Length; t++) {
				Sprite tmp = swappoFish [t];
				int r = Random.Range (t, swappoFish.Length);
				swappoFish [t] = swappoFish [r];
				swappoFish [r] = tmp;
			}
			
			
			GetDaSwappoCoin ();			
			
			activateDaSwappo = true;
			dswanir.enabled = true;
			
			// Debug.Log ("|-oo-| Switcheroo!" + dswsr + " :: " + dswsr.sprite + " :: " + swappoFish + " ::: ");
			
			
		}

		if (Input.GetKeyUp (KeyCode.T) && !activateDaTimeyWimey && !daTimeyWimeyActivated) {
			
			GetDaTimeCoin ();			
			
			
			activateDaTimeyWimey = true;
			//			iterateTimeCoin = true;
			dtcanir.enabled = true;
			
			//			GetDaTimeCoin ();			
			
			// Debug.Log ("|-oo-| TimeyWimey!" + activateDaTimeyWimey + " :: " + daTimeyWimeyActivated + " ::: ");
		}
		



		if (Input.GetKeyUp (KeyCode.A) && daAdBassActivated && !animateDaAdBass) {
			animateDaAdBass = true;
			
		} else {
			animateDaAdBass = false;
		}
		
		if (Input.GetKeyUp (KeyCode.B) && daBadAssActivated && !animateDaBadAss) {
			animateDaBadAss = true;
			
		} else {
			animateDaBadAss = false;
		}

		if (Input.GetKeyUp (KeyCode.C) && daManyFacesActivated) {
			iterateTimeCoin = false;
		} else {
		}

		if (Input.GetKeyUp (KeyCode.S) && daSwappoActivated && !animateDaSwappo) {
			animateDaSwappo = true;
		} else {
			animateDaSwappo = false;
		}
		
		if (Input.GetKeyUp (KeyCode.T) && daTimeyWimeyActivated && !animateDaTimeyWimey) {
			// Debug.Log ("@@@@@");
			animateDaTimeyWimey = true;
		} else {
			animateDaTimeyWimey = false;
		}


		
		if (Input.GetKeyUp (KeyCode.Z)) {
			RemoveBadAssCoin ();
		}
		
		if (activateDaAdBass) {
			activateDaAdBass = false;
			
			daAdBass.gameObject.transform.position = GeneratedPosition ();
			
			
			daAdBassActivated = true;
		}

		if (activateDaFishingPole) {
			daFishingPole.transform.eulerAngles = new Vector3 (daFishingPole.transform.eulerAngles.x, daFishingPole.transform.eulerAngles.y, daFishingPole.transform.eulerAngles.z + 0.03F);
			daFishingPole.transform.FindChild ("fishingrod_bobber").transform.Translate (Vector3.up * Time.deltaTime, Space.World);
			// Debug.Log ("Bobs Your Uncle" + daFishingPole.transform.FindChild ("fishingrod_bobber").transform.position.y);

			if (daFishingPole.transform.FindChild ("fishingrod_bobber").transform.position.y > 12) {
				activateDaFishingPole = false;
				daFishingPoleActivated = false;
				daFishingPole.SetActive (false);
				daFishingPole.transform.position = new Vector3 (-20f, daFishingPole.transform.position.y, daFishingPole.transform.position.z);
			}
		}

		if (activateDaTimeyWimey) {
			activateDaTimeyWimey = false;
			
			daTimeyWimey.gameObject.transform.position = GeneratedPosition ();
			
			
			daTimeyWimeyActivated = true;
		}	
		
		if (activateDaSwappo) {
			activateDaSwappo = false;
			
			daSwappo.gameObject.transform.position = GeneratedPosition ();
			
			
			daSwappoActivated = true;
		}	
		
		if (activateDaHalfOff) {
			activateDaHalfOff = false;
			
			daHalfOff.gameObject.transform.position = GeneratedPosition ();
			
			
			daHalfOffActivated = true;
		}	
		
		if (activateDaManyFaces) {
			activateDaManyFaces = false;
			
			// daSwappo.gameObject.transform.position = GeneratedPosition ();
			manyFacesCoin = Instantiate (coinManager.coinGameObj, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject; 

			manyFacesCoin.gameObject.transform.position = GeneratedPosition ();
			
			daManyFacesActivated = true;

			StartCoroutine (ChangeCoinValue (0.5F));

		}	
		
		if (activateDaBadAss) {
			activateDaBadAss = false;
			
			daBadAss.gameObject.transform.position = GeneratedPosition ();
			
			
			
			daBadAssActivated = true;
			
			//// Debug.Log ("daBadAss " + daBadAss + " :: " + daBadAss.gameObject.transform.position);
		}
		
		if (animateDaBadAss && !daBadAssAnimated) {
			if (daBadAss.tag == "thlump") {
				StartCoroutine (GoToThlump (3.0f));
			}
			daBadAssAnimated = true;
			//// Debug.Log ("|-o-||-o-| daBadAss " + dbanir);
			dbanir.SetTrigger ("tr_badass");
			Invoke ("RemoveBadAssCoin", 3);
		}
		
		if (animateDaSwappo && !daSwappoAnimated) {
			daSwappoAnimated = true;
			StartCoroutine (SwapShop (0.5F));
			
		}
		
		if (animateDaTimeyWimey && !daTimeyWimeyAnimated) {
			dtcanir.enabled = true;
			daTimeyWimeyAnimated = true;
			// Debug.Log ("|-o-||-o-| daBadAss " + dtcanir);
			dtcanir.SetTrigger ("tr_time");


			float rando = Random.Range (0f, 1f);

			// Debug.Log ("|-o-||-o-||-o-| " + rando);

			countdown.userHasHitReturn = false;
			countdown.finalCountDown = false;

			//daTimeyWimey.GetComponent<Animator> ().enabled = false;
			//dtcanir.enabled = false;
			if (rando >= 0.5f) {
				timeFwd = true;
				daTimeyWimey.GetComponent<SpriteRenderer> ().sprite = clockSprite [2];
//				countdown.timeLeft += 10;
				StartCoroutine (TurnBackTime (0.25f, 10, true));
			} else {
				timeFwd = false;
				daTimeyWimey.GetComponent<SpriteRenderer> ().sprite = clockSprite [1];
				if (countdown.timeLeft >= 10) {
					// Debug.Log ("++++10 " + rando);
					//countdown.timeLeft -= 10;
					StartCoroutine (TurnBackTime (0.25f, 10, false));
				} else {
					// Debug.Log ("----10 " + rando);
					StartCoroutine (TurnBackTime (0.25f, countdown.timeLeft, false));
					//					countdown.timeLeft = 0;
//					countdown.gt1.text = "0";
				}
			}
			Invoke ("RemoveTimeCoin", 2.5f);

		}
		
		if (animateDaAdBass && !daAdBassAnimated) {
			rando = coinManager.arrCoins [Random.Range (1, coinManager.arrCoins.Count)];
			// Debug.Log (coinManager.arrCoins.Count + " :: " + rando);
			
			if (rando.tag == "BadAss") {
				rando.GetComponent<Animator> ().enabled = false;
			}
			
			rando.GetComponent<SpriteRenderer> ().sprite = coinManager.bass;
			
			daAdBassAnimated = true;
			//// Debug.Log ("|-o-||-o-| daBadAss " + dbanir);
			dabanir = daAdBass.GetComponent<Animator> ();
			dabanir.enabled = true;

			dabanir.SetTrigger ("tr_badass");
			dabanir.GetComponent<AudioSource> ().Play ();
			Invoke ("RemoveAdBassCoin", 3);
		}
		
	}

	IEnumerator GoFish (float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		activateDaFishingPole = true;
		daFishingPole.GetComponent<AudioSource> ().Play ();
	}

	IEnumerator OffHalfOff (float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		daHalfOff.SetActive (false);
		activateDaHalfOff = false;

	}

	IEnumerator TurnBackTime (float waitTime, float minutes, bool fwd)
	{
		if (minutes < 9) {
			timeCoinCont.timeFU = true;
		} else if (minutes < 8) {
		}


		if (fwd) {
			countdown.timeLeft += 1;
		} else {
			countdown.timeLeft -= 1;
		}
		countdown.counterText = countdown.ParseIntToStr ((int)countdown.timeLeft);
		countdown.gt1.text = countdown.counterText;

		swapSound.clip = tickTock;
		swapSound.Play ();
		yield return new WaitForSeconds (waitTime);
		if (minutes > 0) {


			StartCoroutine (TurnBackTime (waitTime, minutes - 1, fwd));
		} else {
			countdown.userHasHitReturn = true;
			countdown.finalCountDown = true;
		}

	}
	void FixedUpdate ()
	{
	}
	
	
	void GetBadAssCoin (GameObject coin)
	{
		if (coin == null) {
			daBadAss = GenerateRandomBadAss ();//GameObject.Find (GenerateRandomBadAss ());
		} else {
			// Debug.Log ("$$$#####" + coin);
			daBadAss = thlumpCoin;
		}
		
		//daBadAss = GenerateRandomBadAss ();//GameObject.Find (GenerateRandomBadAss ());
		daBadAss.SetActive (true);
		dbasr = daBadAss.GetComponent<SpriteRenderer> ();
		badAssSprite = dbasr.sprite;
		dbanir = daBadAss.GetComponent<Animator> ();
		
		coinManager.arrCoins.Add (daBadAss);
		
		dbanir.Play ("stop");
		
		//// Debug.Log ("|-o-|dba " + daBadAss);
		
		min_x = dbasr.bounds.size.x;
	}
	
	IEnumerator ChangeCoinValue (float waitTime)
	{

		if (iterateTimeCoin) {
			// Debug.Log ("|-o-|" + countTimeyCoin);
			// Debug.Log ("@@@" + coinManager.arrCoinSprites [countTimeyCoin]);
			if (countTimeyCoin == coinManager.arrCoinSprites.Length - 1) {
				countTimeyCoin = 0;
			} else {
				countTimeyCoin += 1;
			}
	

			manyFacesCoin.GetComponent<SpriteRenderer> ().sprite = coinManager.arrCoinSprites [countTimeyCoin];

			swapSound.clip = swapMoving;
			swapSound.Play ();


			yield return new WaitForSeconds (waitTime);
			StartCoroutine (ChangeCoinValue (waitTime));

		} else {
			swapSound.clip = swapLanded;
			swapSound.Play ();

			yield return new WaitForSeconds (waitTime * 2);

			daManyFacesActivated = false;
			Destroy (manyFacesCoin);
		}
	}
	
	IEnumerator SwapShop (float waitTime)
		//	void SwapShop ()
	{
		yield return new WaitForSeconds (waitTime);
		//AudioSource swapSound = dswanir.GetComponent<AudioSource> ();

		if (countSwappo < 6) { 
			dswanir.enabled = false;

			swapSound.clip = swapMoving;
			swapSound.Play ();

			dswsr.sprite = swappoFish [countSwappo];
			countSwappo += 1;
			StartCoroutine (SwapShop (waitTime));
		} else {
			swapSound.clip = swapLanded;
			swapSound.Play ();
			Invoke ("RemoveSwappoCoin", 3);
		}
		
	}

	void RemoveTimeCoin ()
	{

		daTimeyWimey.transform.position = new Vector3 (daTimeyWimey.transform.position.x, -12, daTimeyWimey.transform.position.z);
		GameObject.Find ("daTimeCoin").GetComponent<SpriteRenderer> ().sprite = clockSprite [3];
		activateDaTimeyWimey = false;
		daTimeyWimeyActivated = false;
		animateDaTimeyWimey = false;
		daTimeyWimeyAnimated = false;
		timeCoinCont.timeFU = false;



		// Debug.Log ("Fuck You");

	}
	void RemoveSwappoCoin ()
	{
		countSwappo = 0;
		
		//		coinManager.arrCoins.Remove (daSwappo);
		//		daSwappo.GetComponent<Animator> ().enabled = true;
		//		daSwappo.GetComponent<SpriteRenderer> ().sprite = badAssSprite;
		
		//		daSwappo.SetActive (false);
		
		daSwappo.transform.position = new Vector3 (daSwappo.transform.position.x, -12, daSwappo.transform.position.z);
		activateDaSwappo = false;
		daSwappoActivated = false;
		animateDaSwappo = false;
		daSwappoAnimated = false;
	}
	
	void RemoveBadAssCoin ()
	{
		coinManager.arrCoins.Remove (daBadAss);
		daBadAss.GetComponent<Animator> ().enabled = true;
		daBadAss.GetComponent<SpriteRenderer> ().sprite = badAssSprite;
		
		daBadAss.SetActive (false);
		activateDaBadAss = false;
		daBadAssActivated = false;
		animateDaBadAss = false;
		daBadAssAnimated = false;
		//	Destroy (daBadAss);
	}
	
	void GetDaTimeCoin ()
	{
		daTimeyWimey.SetActive (true);
		dtcsr = daTimeyWimey.GetComponent<SpriteRenderer> ();
		dtcsr.sprite = swappoSprite;
		dtcanir = daTimeyWimey.GetComponent<Animator> ();
		dtcanir.Play ("stop");
		
		// Debug.Log ("Allonsey!" + dtcsr + " :: " + dtcsr.sprite);
	}
	
	void GetDaSwappoCoin ()
	{
		daSwappo.SetActive (true);
		dswsr = daSwappo.GetComponent<SpriteRenderer> ();
		dswsr.sprite = swappoSprite;
		dswanir = daSwappo.GetComponent<Animator> ();
		
		dswanir.Play ("stop");
		
		//// Debug.Log ("|-o-|dba " + daBadAss);
		
		//min = dabanir.bounds.size.x;
		// Debug.Log ("Switcheroo!" + dswsr + " :: " + dswsr.sprite);
	}
	
	void GetAdBassCoin ()
	{
		dabsr = daAdBass.GetComponent<SpriteRenderer> ();
		dabanir = daAdBass.GetComponent<Animator> ();
		dabanir.enabled = true;
		
		dabanir.Play ("stop");
		
		//// Debug.Log ("|-o-|dba " + daBadAss);
		
		//min = dabanir.bounds.size.x;
	}
	
	void RemoveAdBassCoin ()
	{
		if (rando.tag == "BadAss") {
			RemoveBadAssCoin ();
		}
		
		
		//		daAdBass.SetActive (false);
		daAdBass.transform.position = new Vector3 (daAdBass.transform.position.x, -12, daAdBass.transform.position.z);
		activateDaAdBass = false;
		daAdBassActivated = false;
		animateDaAdBass = false;
		daAdBassAnimated = false;
		animateDaSwappo = false;
		daSwappoAnimated = false;
		//	Destroy (daBadAss);
	}
	
	//	string GenerateRandomBadAss ()
	GameObject GenerateRandomBadAss ()
	{
		whichCoinIndex = Random.Range (0, anim_names.Length);
		whichCoin = anim_names [whichCoinIndex];
		// Debug.Log ("@@@@@@@@@" + whichCoinIndex + " :: " + whichCoin);
		//return anim_names [Random.Range (0, anim_names.Length)];
		
		
		return arrDaBadAss [whichCoinIndex];
	}
	
	Vector3 GeneratedPosition ()
	{
		float x, y, z;
		float x_min = min_x;
		float rando = Random.Range (0f, 1f);
		if (rando > 0.85f) {
			x_min = 2f;
		}
		x = Random.Range (x_min, max_x);
		y = Random.Range (min_y, max_y);
		z = 0;//Random.Range(min,max);
		Debug.Log ("GeneratedPosition" + " :: " + x + ":" + y + " ::: " + rando + " || " + x_min);
		return new Vector3 (x, y, z);
	}
	
	IEnumerator GoToThlump (float waitTime)
	{
		showThlump = true;
		yield return new WaitForSeconds (waitTime);
		showThlump = false;
		
	}
}
