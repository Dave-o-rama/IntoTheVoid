using UnityEngine;
using System.Collections;

public class FloorMaterialOffset : MonoBehaviour {

	public float scrollSpeed = 0.5F;
	private MeshRenderer rend;

	void Start() {
		rend = GetComponent<MeshRenderer>();
	}

	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
