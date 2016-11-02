using UnityEngine;
using System.Collections;

public class SpawnNoise : MonoBehaviour {

	private ExplodingCube _explodingCube;

	public GameObject visualNoise;
	public GameObject audioNoise;

	void Start () {
		_explodingCube = GetComponent<ExplodingCube> ();
	}

	void OnDestroy(){
		if (_explodingCube != null) {
			while (_explodingCube.cubeValue > 0) {
				Instantiate (visualNoise, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, Random.Range (0, 359))));
				_explodingCube.cubeValue--;
			}
		} else {
			Instantiate (visualNoise, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, Random.Range (0, 359))));
		}

		Instantiate (audioNoise, this.gameObject.transform.position, Quaternion.identity);
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
