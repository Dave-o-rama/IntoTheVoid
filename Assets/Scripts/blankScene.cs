using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class blankScene : MonoBehaviour {

	private GameData _gameData;

	// Use this for initialization
	void Start () {
		_gameData = GameObject.Find ("GameData").GetComponent<GameData> ();

		if (_gameData.lastMenuButtonClicked == "newGame") {
			SceneManager.LoadScene ("Prototype");
		} else if (_gameData.lastMenuButtonClicked == "MainMenu") {
			SceneManager.LoadScene ("MainMenu");
		} else {
			print ("GameData string != something important");
			SceneManager.LoadScene ("MainMenu");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
