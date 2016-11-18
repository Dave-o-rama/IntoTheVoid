using UnityEngine;
using System.Collections;

public class LoseGame : MonoBehaviour {

	public int waveLost;
	private TextMesh _waveCounter;

	void OnEnable(){
		_waveCounter = GetComponent<TextMesh> ();
		waveLost = GameObject.Find ("Main Camera").GetComponent<CameraClicker> ().waveLost;


		if (waveLost == 1) {
			_waveCounter.text = "You did not survive a single wave. Weakling.";
		} else if(waveLost == 2){
			int derp = waveLost - 1;
			_waveCounter.text = ("You survived " + derp + " wave before the universe collapsed.");
		}else{
			int derp = waveLost - 1;
			_waveCounter.text = ("You survived " + derp + " waves before the universe collapsed.");
		}
	}
}
