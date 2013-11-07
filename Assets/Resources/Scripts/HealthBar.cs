using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour {
	
	public Vector3 offset = new Vector3(0, 1, 0);
	public Texture2D blankTexture;
	public Vector2 size = new Vector2(0.5f, 0.1f);
	
	private Health healthComponent;
	
	// Use this for initialization
	void Start () {
		healthComponent = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
