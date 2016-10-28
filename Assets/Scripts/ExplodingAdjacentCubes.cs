using UnityEngine;
using System.Collections;

public class ExplodingAdjacentCubes : MonoBehaviour {

	void Start(){
		Collider[] otherBricks = new Collider[10];
		otherBricks = Physics.OverlapSphere (new Vector3 (0f, 0f, 0f), 2f);
		int i = 0;
		while (i < otherBricks.Length) {
			print (otherBricks [i].gameObject);
			i++;
		}
	}

	void OnDestroy(){
		print ("meme");
	}
}
