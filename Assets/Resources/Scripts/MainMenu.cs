using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private ScreenFader fader;
	
	// Use this for initialization
	void Start () {
		fader = GetComponent<ScreenFader>();
		fader.Fade(1f, 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnGUI() {
		if(GUI.Button(new Rect((0.5f * Screen.width) - 50f, 0.7f * Screen.height, 100f, 40f), "New Game")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect((0.5f * Screen.width) - 30f, 0.9f * Screen.height, 60f, 30f), "Quit")) {
			Application.Quit();
		}
		GUI.Label(new Rect((0.5f * Screen.width) - 300f, 0.2f * Screen.height, 600f, 30f), "Teh Game");
	}
}
