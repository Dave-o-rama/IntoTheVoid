using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class CameraClicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit mouseRayHit = new RaycastHit ();
		var mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (mouseRay.origin, mouseRayHit.point, Color.red);

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (mouseRay, out mouseRayHit, 10f)) {

			if (mouseRayHit.transform.gameObject.tag == "regularCube") {
				mouseRayHit.transform.GetComponent<BasicCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "cannotClickCube") {
				mouseRayHit.transform.GetComponent<CannotClickCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "explodingCube") {
				mouseRayHit.transform.GetComponent<ExplodingCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "shrinkCube") {
				mouseRayHit.transform.GetComponent<ShrinkCube> ().isClicked = true;
			} else if (mouseRayHit.transform.gameObject.tag == "win") {
				print ("YOU WIN!");
			}




		}

	}

	void OnApplicationQuit(){
		Destroy (this.gameObject);
	}
}
