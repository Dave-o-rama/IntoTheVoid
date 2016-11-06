using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[ExecuteInEditMode]

public class CameraClicker : MonoBehaviour {

	public GameObject winMenu;
	public GameObject loseMenu;
	private PlayerMovement _playerMovement;
	private ClickTracker _clickTracker;

	// Use this for initialization
	void Start () {
		_playerMovement = GetComponent<PlayerMovement> ();
		_clickTracker = GameObject.Find ("ClickTracker").GetComponent<ClickTracker>();

		winMenu.SetActive (false);
		loseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit mouseRayHit = new RaycastHit ();
		var mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (mouseRay.origin, mouseRayHit.point, Color.red);

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (mouseRay, out mouseRayHit, 10f) && !_clickTracker.gameLost) {

			if (mouseRayHit.transform.gameObject.tag == "regularCube") {
				mouseRayHit.transform.GetComponent<BasicCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "cannotClickCube") {
				mouseRayHit.transform.GetComponent<CannotClickCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "explodingCube") {
				mouseRayHit.transform.GetComponent<ExplodingCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "shrinkCube") {
				mouseRayHit.transform.GetComponent<ShrinkCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "win") {
				GameObject[] visualNoise = GameObject.FindGameObjectsWithTag("visualNoise");
				GameObject[] audioNoise = GameObject.FindGameObjectsWithTag("audio");

				for (int i = 0; i < visualNoise.Length; i++) {
					Destroy (visualNoise [i]);
				}

				for (int j = 0; j < audioNoise.Length; j++) {
					Destroy (audioNoise [j]);
				}
				_playerMovement.enabled = false;
				winMenu.SetActive (true);
			}




		}

		if (_clickTracker.gameLost) {
			_playerMovement.enabled = false;
			loseMenu.SetActive (true);
		}

	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
