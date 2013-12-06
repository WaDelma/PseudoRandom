using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	
	public Vector3 rotationSpeed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotationSpeed * Time.deltaTime);
	}
}
