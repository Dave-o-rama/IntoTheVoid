using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float leftMovementSpeed;
	public float rightMovementSpeed;
	public float forwardMovementSpeed;
	public float backwardMovementSpeed;

	public float slowdownRate;

	private float initialLeftMovementSpeed;
	private float initialRightMovementSpeed;
	private float initialForwardMovementSpeed;
	private float initialBackwardMovementSpeed;

	private Rigidbody _rigidbody;
	private ClickTracker _clickTracker;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		_clickTracker = GameObject.Find("ClickTracker").GetComponent<ClickTracker> ();

		initialLeftMovementSpeed = leftMovementSpeed;
		initialRightMovementSpeed = rightMovementSpeed;
		initialForwardMovementSpeed = forwardMovementSpeed;
		initialBackwardMovementSpeed = backwardMovementSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (_clickTracker.volumeModifier != 0) {
			leftMovementSpeed = initialLeftMovementSpeed - (_clickTracker.volumeModifier * slowdownRate);
			rightMovementSpeed = initialRightMovementSpeed - (_clickTracker.volumeModifier * slowdownRate);
			forwardMovementSpeed = initialForwardMovementSpeed - (_clickTracker.volumeModifier * slowdownRate);
			backwardMovementSpeed = initialBackwardMovementSpeed - (_clickTracker.volumeModifier * slowdownRate);
		}

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
