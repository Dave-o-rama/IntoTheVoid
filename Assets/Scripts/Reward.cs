using UnityEngine;
using System.Collections;

public class Reward : MonoBehaviour {

	void OnMouseEnter(){
		this.gameObject.transform.position += new Vector3 (0f, 0.1f, 0f);
	}

	void OnMouseExit(){
		this.gameObject.transform.position -= new Vector3 (0f, 0.1f, 0f);
	}
}
