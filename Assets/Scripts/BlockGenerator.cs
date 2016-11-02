using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject[] bricks;

	public int blocksWide;
	public int blocksDeep;

	public bool shrinkBrickDropped = false;

	// Use this for initialization
	void Awake () {
		while (blocksDeep > 0) {

			while (blocksWide > 0) {

				int i;

				if (!shrinkBrickDropped) {
					i = Random.Range (0, bricks.Length);
				} else {
					i = Random.Range (0, 3);
				}

				if (i == 1) {
					int j = Random.Range (0, 100);
					if (j > 80 && j < 90) {
						i = 0;
					}if (j > 91) {
						i = 2;
					}
				}

				if (i == 2) {
					int j = Random.Range (0, 100);
					if (j < 30) {
						i = 0;
					}

					Instantiate (bricks [i], transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
				} else {
					Instantiate (bricks [i], transform.position, Quaternion.identity);
				}

				if (i == 3) {
					shrinkBrickDropped = true;
				}

				this.gameObject.transform.position += new Vector3 (1.1f, 0f, 0f);
				blocksWide--;
			}

			this.gameObject.transform.position += new Vector3 (-4.4f, 0f, 1.1f);
			blocksWide = 4;
			blocksDeep--;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
