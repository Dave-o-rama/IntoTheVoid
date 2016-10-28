﻿using UnityEngine;
using System.Collections;

public class BasicCube : MonoBehaviour {

	private CameraClicker cameraClicker;
	public bool isClicked = false;

	// Use this for initialization
	void Start () {
		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			Destroy (this.gameObject);
		}

	}
}
