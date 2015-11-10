using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class PlayerShooting : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES - Exposed on the Inspector
	public ParticleSystem muzzleFlash;
	public GameObject impact;
	public Animator rifleAnimator;
	public AudioSource bulletFireSound;

	// PRIVATE INSTANCE VARIABLES 
	private GameObject[] _impacts;
	private int _currentImpact = 0;
	private int _maxImpacts = 5; 

	private bool _shooting = false;

	// Use this for initialization
	void Start () {

		this._impacts = new GameObject[this._maxImpacts];
		for (int impactCount = 0; impactCount < this._maxImpacts; impactCount++) {
			this._impacts[impactCount] = (GameObject) Instantiate(this.impact);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		// play muzzle flash and shoot impact when left-mouse button is pressed
		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			this._shooting = true;
			this.muzzleFlash.Play();
			this.bulletFireSound.Play();
			this.rifleAnimator.SetTrigger("Fire");
		}

		if(CrossPlatformInputManager.GetButtonUp("Fire1")) {
			this._shooting = false;
		}
	
	}

	// Physics effects
	void FixedUpdate() {
	}
}
