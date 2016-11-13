using UnityEngine;
using System.Collections;

public class RandomizeAudioNoise : MonoBehaviour {

	private AudioSource _audio;

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource> ();

		_audio.volume = 0.01f + GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().volumeModifier;
		_audio.pitch = Random.Range (0f, 2f);
	}
	
	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
