using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomizeVisualNoise : MonoBehaviour {

	private float cubesClicked;
	private float cubesClickedToLose;
	public float colorAlpha;

	// Use this for initialization
	void Start () {
		cubesClicked = GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClicked;
		cubesClickedToLose = GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClickedToLose;

		if (cubesClicked <= cubesClickedToLose * .25f) {
			colorAlpha = .011f;
		}else if (cubesClicked > cubesClickedToLose * .25f && cubesClicked <= cubesClickedToLose * .5f) {
			colorAlpha = .022f;
		}else if (cubesClicked > cubesClickedToLose * .5f && cubesClicked <= cubesClickedToLose * .75f) {
			colorAlpha = .033f;
		}else {
			colorAlpha = .044f;
		}

		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), colorAlpha);
	}
	
	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
