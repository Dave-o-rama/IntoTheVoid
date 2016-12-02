using UnityEngine;
using System.Collections;

public class BasicCube : MonoBehaviour {

	public int cubeValue;
	private CameraClicker cameraClicker;
	public bool isClicked = false;

	public GameObject deathParticle;

	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClicked += cubeValue;
			Instantiate (deathParticle, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
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
