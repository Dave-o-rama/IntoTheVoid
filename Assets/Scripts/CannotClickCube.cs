using UnityEngine;
using System.Collections;

public class CannotClickCube : MonoBehaviour {

	public float smallTime;
	private float initialSmallTime;

	private CameraClicker cameraClicker;
	public bool isClicked = false;


	// Use this for initialization
	void Start () {
		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
		initialSmallTime = smallTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			gameObject.transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
			smallTime -= Time.deltaTime;
		}

		if (smallTime <= 0) {
			smallTime = initialSmallTime;
			gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
			isClicked = false;
		}

	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
