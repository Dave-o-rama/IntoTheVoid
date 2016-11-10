using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickTracker : MonoBehaviour {

	public int cubesClicked = 0;
	public float volumeModifier;

	public float noiseIncrease;
	public int cubesClickedToLose;

	public bool gameLost = false;

	// Use this for initialization
	void Awake () {
		cubesClickedToLose = (int)((GameObject.Find ("GameData").GetComponent<GameData> ().fieldWidth * GameObject.Find ("GameData").GetComponent<GameData> ().fieldDepth) / 2.88f);
	}
	
	// Update is called once per frame
	void Update () {
		volumeModifier = cubesClicked * noiseIncrease;

		if (cubesClicked >= cubesClickedToLose) {
			gameLost = true;
		}
	}
}
