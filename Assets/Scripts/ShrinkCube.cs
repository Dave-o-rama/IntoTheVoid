﻿using UnityEngine;
using System.Collections;

public class ShrinkCube : MonoBehaviour {

	private CameraClicker cameraClicker;
	public bool isClicked = false;
	public GameObject edgeFloor;


	// Use this for initialization
	void Start () {
		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClicked++;
			Destroy (edgeFloor);
			Destroy (this.gameObject);
		}
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
