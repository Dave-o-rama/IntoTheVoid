using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomizeVisualNoise : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector3 (Random.Range (-600, 600), Random.Range (-600, 600), 0f);
		GetComponent<Image> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 0.03f);
		this.gameObject.transform.Rotate (new Vector3 (0f, 0f, Random.Range (0, 359)));
	}
	
	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
