using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	
	private Texture fadeTexture;
	private float startValue = 0.0f;
	private float endValue = 1.0f;
	private float currentValue  = 0.0f;
	private float speed = 0.1f;
	private bool fade = false;
	
	// Use this for initialization
	void Start () {
		fadeTexture = (Texture) Resources.Load("Textures/black texture");
	}
	
	// Update is called once per frame
	void Update () {
		if(fade) {
			currentValue += startValue > endValue ? -speed * Time.deltaTime : speed * Time.deltaTime;
			bool fadeComplete = startValue > endValue ? currentValue <= endValue : currentValue >= endValue;
			if(fadeComplete) {
				currentValue = endValue;
				fade = false;
			}
		}
	}
	
	public void OnGUI() {
		GUI.color = new Color(0, 0, 0, currentValue);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
	}
	
	public void Fade(float startValue, float endValue, float speed) {
		this.startValue = startValue;
		this.currentValue = startValue;
		this.endValue = endValue;
		this.speed = speed;
		this.fade = true;
	}
	
	public bool FadeComplete() {
		return !fade;
	}
}
