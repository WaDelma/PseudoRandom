using UnityEngine;
using System.Collections;

public class Velocity : MonoBehaviour {
	
	public float speed = 10.0f;
	public Vector3 direction = Vector3.down;
	
	// Use this for initialization
	void Start () {
		direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
	}
}
