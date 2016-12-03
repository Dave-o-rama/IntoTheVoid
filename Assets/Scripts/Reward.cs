using UnityEngine;
using System.Collections;

public class Reward : MonoBehaviour {

	MeshRenderer rend;
	public Color rewardColor;

	void Start(){
		this.gameObject.transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0, 359), Random.Range (0, 359), Random.Range (0, 359)));

		rend = GetComponent<MeshRenderer>();
		rewardColor = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1f);
		rend.material.color = rewardColor;
		rend.material.SetColor ("_EmissionColor", rewardColor);

		GetComponentInChildren<Light> ().color = rewardColor;
	}

	void OnMouseEnter(){
		this.gameObject.transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
	}

	void OnMouseExit(){
		this.gameObject.transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
	}
}
