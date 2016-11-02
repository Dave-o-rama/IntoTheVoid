using UnityEngine;
using System.Collections;
using System;

public class ExplodingAdjacentCubes : MonoBehaviour {

	GameObject[] thingsToDestroy;
	public int cubesToDestroy = 0;

	void Start(){
		thingsToDestroy = new GameObject[24];
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "cannotClickCube" || col.gameObject.tag == "shrinkCube" || col.gameObject.tag == "regularCube" || col.gameObject.tag == "explodeCube") {
			thingsToDestroy [cubesToDestroy] = col.gameObject;
			cubesToDestroy++;
		}


	}

	void OnDestroy(){
		int i = 0;
		while (i <= cubesToDestroy) {
			Destroy (thingsToDestroy [i]);
			++i;
		}
	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
