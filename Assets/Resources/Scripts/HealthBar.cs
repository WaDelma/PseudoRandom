using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour {
	
	public Vector3 offset = new Vector3(0, 2, 0);
	
	private Health healthComponent;
	
	// Use this for initialization
	void Start () {
		healthComponent = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnGUI() {
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position + offset);
		if(position.z > 0 && position.z < 10) {
			GUI.Box(new Rect(position.x - 50f, Screen.height - position.y, 100f, 20f), "hp: " + healthComponent.GetHealth() + "/" + healthComponent.maxHealth);
		}
	}
}
