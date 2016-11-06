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
				GameObject visualJawn = Instantiate (visualNoise, GameObject.Find ("VisualNoise").transform.position, Quaternion.Euler (new Vector3 (0f, 0f, Random.Range (0, 359)))) as GameObject;
				visualJawn.transform.parent = GameObject.Find ("VisualNoise").transform;
				Instantiate (audioNoise, this.gameObject.transform.position, Quaternion.identity);
				_explodingCube.cubeValue--;
			}
		} else {
			GameObject visualJawn = Instantiate (visualNoise, GameObject.Find ("VisualNoise").transform.position, Quaternion.Euler (new Vector3 (0f, 0f, Random.Range (0, 359)))) as GameObject;
			visualJawn.transform.parent = GameObject.Find ("VisualNoise").transform.parent;
		}

		Instantiate (audioNoise, this.gameObject.transform.position, Quaternion.identity);
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
