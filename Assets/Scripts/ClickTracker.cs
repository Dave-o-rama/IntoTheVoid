using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickTracker : MonoBehaviour {

	public int cubesClicked = 0;
	public float volumeModifier;

	public float noiseIncrease;
	public int cubesClickedToLose;

	public bool gameLost = false;

	public int gamePhase = 0;

	// Use this for initialization
	void Awake () {
		cubesClickedToLose = (int)((GameObject.Find ("GameData").GetComponent<GameData> ().fieldWidth * GameObject.Find ("GameData").GetComponent<GameData> ().fieldDepth) / 3.1f);
	}
	
	// Update is called once per frame
	void Update () {
		volumeModifier = cubesClicked * noiseIncrease;

		if (cubesClicked >= cubesClickedToLose) {
			gameLost = true;
		}

		if (cubesClicked <= cubesClickedToLose * .25f) {
			gamePhase = 1;
		}else if (cubesClicked > cubesClickedToLose * .25f && cubesClicked <= cubesClickedToLose * .5f) {
			gamePhase = 2;
		}else if (cubesClicked > cubesClickedToLose * .5f && cubesClicked <= cubesClickedToLose * .75f) {
			gamePhase = 3;
		}else {
			gamePhase = 4;
		}
	}
}
