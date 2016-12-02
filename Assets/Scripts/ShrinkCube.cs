using UnityEngine;
using System.Collections;

public class ShrinkCube : MonoBehaviour {

	public int cubeValue;

	private CameraClicker cameraClicker;
	public bool isClicked = false;
	public GameObject edgeFloor;
	public GameObject edgeBarrier;

	private Rigidbody _rigidbody;

	public GameObject deathParticle;


	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();

		cameraClicker = GameObject.Find("Main Camera").GetComponent<CameraClicker> ();
		edgeFloor = GameObject.Find ("BrickGenerator").GetComponent<BlockGenerator> ().shrinkFloor;
		//edgeBarrier = GameObject.Find ("RightBarrier");
		//edgeBarrier.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			GameObject.Find ("ClickTracker").GetComponent<ClickTracker> ().cubesClicked += cubeValue;
			Instantiate (edgeBarrier, edgeFloor.transform.position + new Vector3(0f,2.5f,0f), Quaternion.identity);
			Instantiate (deathParticle, transform.position, Quaternion.Euler(new Vector3(0f,-90f,0f)));
			Destroy (edgeFloor);
			//GameObject.Find ("Wall_V2(Clone)").transform.position -= new Vector3 (1.1f, 0f, 0f);
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
