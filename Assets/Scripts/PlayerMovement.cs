using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float leftMovementSpeed;
	public float rightMovementSpeed;
	public float forwardMovementSpeed;
	public float backwardMovementSpeed;

	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			_rigidbody.AddForce(new Vector3 (rightMovementSpeed, 0f, 0f));
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			_rigidbody.AddForce(new Vector3 (-leftMovementSpeed, 0f, 0f));
		}

		if (Input.GetAxis ("Vertical") > 0) {
			_rigidbody.AddForce(new Vector3 (0f, 0f, forwardMovementSpeed));
		}

		if (Input.GetAxis ("Vertical") < 0) {
			_rigidbody.AddForce(new Vector3 (0f, 0f, -backwardMovementSpeed));
		}

	}
}
