using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class DiscoLight : MonoBehaviour {
	
	public float colorSpeed = 1f;
	public float flickerSpeed = 0f;
	
	private Light light;
	private bool on = true;
	private float lastFlickerTime;
	private float lightIntensity;
	
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		lightIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		SlideColor();
		Flicker();

	}
	
	private void SlideColor() {
		HSBColor hsb = HSBColor.FromColor(light.color);
		hsb.h += colorSpeed * Time.deltaTime;
		if(hsb.h > 1f) hsb.h -= 1f;
		light.color = hsb.ToColor();
	}
	
	private void Flicker() {
		if(flickerSpeed > 0 && (Time.time - lastFlickerTime) > flickerSpeed) {
			lastFlickerTime = Time.time;
			on = !on;
		}
		if(on) light.intensity = lightIntensity;
		else light.intensity = 0f;
	}
}
