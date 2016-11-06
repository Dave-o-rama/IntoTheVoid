using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public string lastMenuButtonClicked;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
