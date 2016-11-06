using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntoTheVoidUI : MonoBehaviour {

	private SpriteRenderer _renderer;
	public Color idleColor;
	public Color hoverColor;
	public Color clickedColor;

	public bool isButton;
	public string nextLevel;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		_renderer.color = hoverColor;
	}

	void OnMouseExit(){
		_renderer.color = idleColor;
	}

	void OnMouseDown(){
		_renderer.color = clickedColor;

		if (isButton) {
			GameObject.Find ("GameData").GetComponent<GameData> ().lastMenuButtonClicked = this.gameObject.name;
			if (nextLevel != null) {
				SceneManager.LoadScene (nextLevel);
			} else {
				Application.Quit();
			}
		}
	}

	void OnMouseUpAsButton(){
		_renderer.color = hoverColor;
	}
}
