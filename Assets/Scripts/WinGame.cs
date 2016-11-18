using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	private TextMesh _waveCounter;

	void OnEnable(){
		_waveCounter = GetComponent<TextMesh> ();
		_waveCounter.text = ("Waves Survived: " + GameObject.Find("GameData").GetComponent<GameData> ().currentWave);
	}
}
