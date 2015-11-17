using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Text scoreLabel;
	public Text livesLabel;

	// PRIVATE INSTANCE VARIABLES ++++++++++++
	private int _scoreValue;
	private int _livesValue;

	// PUBLIC PROPERTIES +++++++++++++++++++++
	public int Score {
		get {
			return this._scoreValue;
		}
		set {
			this._scoreValue = value;
			this._updateScoreBoard();
		}
	}

	// Add score to _scoreValue Instance Variable
	public void AddScore(int value) {
		this._scoreValue += value;
		this._updateScoreBoard();
	}

	public int Lives {
		get {
			return this._livesValue;
		}
		set {
			this._livesValue = value;
			this._updateScoreBoard();
		}
	}

	// Add lives to _livesValue Instance Variable
	public void AddLives(int value) {
		this._livesValue += value;
		this._updateScoreBoard();
	}

	// Subtract lives from _livesValue Instance Variable
	public void SubtractLives(int value) {
		this._livesValue -= value;
		this._updateScoreBoard();
	}

	// Use this for initialization
	void Start () {
		this._scoreValue = 0;
		this._livesValue = 100;
		this._updateScoreBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//PRIVATE METHODS
	private void _updateScoreBoard(){
		this.scoreLabel.text = "Score: " + this._scoreValue;
		this.livesLabel.text = "Lives: " + this._livesValue;
	}



}












