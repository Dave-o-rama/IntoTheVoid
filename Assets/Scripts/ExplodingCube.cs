using UnityEngine;
using System.Collections;

public class ExplodingCube : MonoBehaviour {

	public int cubeValue;
	private CameraClicker cameraClicker;
	public bool isClicked = false;

	// Use this for initialization
	void Start () {
		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClicked += cubeValue;
			Destroy (this.gameObject);
		}
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
