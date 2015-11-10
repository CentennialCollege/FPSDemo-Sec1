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
	public AudioSource bulletImpactSound;
	public GameObject explosion;

	// PRIVATE INSTANCE VARIABLES 
	private GameObject[] _impacts;
	private int _currentImpact = 0;
	private int _maxImpacts = 5; 
	private Transform _transform;

	private bool _shooting = false;

	// Use this for initialization
	void Start () {
		// reference to the gameObject's transform component
		this._transform = gameObject.GetComponent<Transform> ();

		// Object pool for impacts
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
		if (this._shooting) {
			this._shooting = false;

			RaycastHit hit;

			if(Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f)) {
				if(hit.transform.CompareTag("Barrel")) {
					Destroy(hit.transform.gameObject);
					Instantiate(this.explosion, hit.point, Quaternion.identity);
				}


				//move impact particle system to location of ray hit
				this._impacts[this._currentImpact].transform.position = hit.point;
				// play the particle effect (impact)
				this._impacts[this._currentImpact].GetComponent<ParticleSystem>().Play();
				// play impact sound
				this.bulletImpactSound.Play();

				// ensure that you don't go out of bounds of the object pool
				if(++this._currentImpact >= this._maxImpacts) {
					this._currentImpact = 0;
				}

			}
		}
	}
}
