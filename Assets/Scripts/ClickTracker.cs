using UnityEngine;
using System.Collections;

public class ClickTracker : MonoBehaviour {

	public int cubesClicked = 0;
	public float volumeModifier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		volumeModifier = cubesClicked * .023f;
	}
}
