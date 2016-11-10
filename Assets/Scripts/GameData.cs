using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public string lastMenuButtonClicked;
	public int fieldWidth;
	public int fieldDepth;
	public int currentWave;
	[HideInInspector] public int initialFieldWidth;
	[HideInInspector] public int initialFieldDepth;

	// Use this for initialization
	void Start () {
		if (currentWave == 0) {
			initialFieldDepth = fieldDepth;
			initialFieldWidth = fieldWidth;
		}

		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
