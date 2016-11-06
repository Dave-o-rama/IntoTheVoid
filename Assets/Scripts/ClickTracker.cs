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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		volumeModifier = cubesClicked * noiseIncrease;

		if (cubesClicked >= cubesClickedToLose) {
			gameLost = true;
		}
	}
}
