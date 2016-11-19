using UnityEngine;
using System.Collections;

public class IronAdjacentCubes : MonoBehaviour {
	
	GameObject[] thingsToDestroy;
	public GameObject regularCube;
	public int cubesToDestroy = 0;
	public bool willCheckOtherCubes;

	void Start(){
		thingsToDestroy = new GameObject[24];

		int j = Random.Range (0, 100);
		if (j <= 20) {
			willCheckOtherCubes = true;
		} else {
			willCheckOtherCubes = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "cannotClickCube") {
			thingsToDestroy [cubesToDestroy] = col.gameObject;
			cubesToDestroy++;
		}

		if (cubesToDestroy <= 6 && willCheckOtherCubes) {
			int j = Random.Range (0, thingsToDestroy.Length);
			Instantiate (regularCube, thingsToDestroy[j].transform.position, Quaternion.identity);
			Destroy (thingsToDestroy [j]);
		}
	}

	
}
