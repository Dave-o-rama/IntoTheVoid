using UnityEngine;
using System.Collections;

public class CannotClickCube : MonoBehaviour {
	
	public float smallTime;
	private float initialSmallTime;

	private CameraClicker cameraClicker;
	public bool isClicked = false;

	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();

		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
		initialSmallTime = smallTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			gameObject.transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
			smallTime -= Time.deltaTime;
		}

		if (smallTime <= 0) {
			smallTime = initialSmallTime;
			gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
			isClicked = false;
		}

	}

	void OnMouseEnter(){
		_rigidbody.useGravity = false;
		_rigidbody.isKinematic = true;
		this.gameObject.transform.position += new Vector3 (0f, 0.1f, 0f);
	}

	void OnMouseExit(){
		_rigidbody.useGravity = true;
		_rigidbody.isKinematic = false;
		this.gameObject.transform.position -= new Vector3 (0f, 0.1f, 0f);
	}


	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
