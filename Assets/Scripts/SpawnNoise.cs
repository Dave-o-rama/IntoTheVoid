using UnityEngine;
using System.Collections;

public class SpawnNoise : MonoBehaviour {

	//public GameObject canvas;
	public GameObject visualNoise;
	public GameObject audioNoise;

	void OnDestroy(){
		Instantiate (visualNoise, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, Random.Range (0, 359))));
		Instantiate (audioNoise, this.gameObject.transform.position, Quaternion.identity);
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
