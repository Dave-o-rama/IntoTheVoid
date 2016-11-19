using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject[] bricks;
	public GameObject floor;
	public GameObject rightWall;
	public GameObject frontWall;
	public GameObject reward;
	[HideInInspector] public GameObject shrinkFloor;

	public int gridWidth;
	private int blocksWide;
	public int blocksDeep;

	public bool shrinkBrickDropped = false;

	public bool floorDropped = false;
	public int floorsCount = 0;

	public bool rightWallDropped = false;

	// Use this for initialization
	void Awake () {
		gridWidth = GameObject.Find ("GameData").GetComponent<GameData> ().fieldWidth;
		blocksDeep = GameObject.Find ("GameData").GetComponent<GameData> ().fieldDepth;
		GameObject.Find ("GameData").GetComponent<GameData> ().currentWave++;

		if (GameObject.Find ("GameData").GetComponent<GameData> ().currentWave == 3) {
			gridWidth = 4;
		}

		blocksWide = gridWidth;

		while (blocksDeep > 0) {

			while (blocksWide > 0) {

				int i;

				/// 0 = regular
				/// 1 = cannotClick
				/// 2 = explode
				/// 3 = shrink

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
					if (j < 40) {
						int k = Random.Range (0, 20);
						if (k >= 14) {
							i = 0;
						} else {
							i = 2;
						}
					}

					Instantiate (bricks [i], transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
				} else {
					Instantiate (bricks [i], transform.position, Quaternion.identity);
				}

				if (i == 3) {
					shrinkBrickDropped = true;
				}



				if (!floorDropped) {
					shrinkFloor = Instantiate (floor, transform.position - new Vector3(0f,1.1f,0f), Quaternion.identity) as GameObject;
					floorsCount++;
				}

				this.gameObject.transform.position += new Vector3 (1.1f, 0f, 0f);
				blocksWide--;
			}

			if (floorsCount == gridWidth) {
				floorDropped = true;
			}

			if (floorDropped && !rightWallDropped) {
				Instantiate (rightWall, transform.position, Quaternion.identity);
				rightWallDropped = true;
			}


			this.gameObject.transform.position += new Vector3 (gridWidth * -1.1f, 0f, 1.1f);
			blocksWide = gridWidth;
			blocksDeep--;
		}

		Instantiate (frontWall, transform.position + new Vector3 (0f, 0f, 10f), Quaternion.identity);
		Instantiate (reward, transform.position + new Vector3((gridWidth / 2f), 0f, 8.5f), Quaternion.identity);

		ModifyField ();
	}
	
	// Update is called once per frame
	void ModifyField () {
		GameObject.Find ("GameData").GetComponent<GameData> ().fieldWidth = gridWidth + 2;
		GameObject.Find ("GameData").GetComponent<GameData> ().fieldDepth += 2;
	}
}
