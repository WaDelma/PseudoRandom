using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {
	
	public float speed = 1f;
	public float zMin = 2f;
	public float zMax = 10f;
	public bool increase = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float amount = speed * Time.deltaTime;
		amount = increase ? amount : -amount;
		transform.position += transform.forward * amount;
		
		if(transform.localPosition.z < zMin || transform.localPosition.z > zMax) {
			increase = !increase;
		}
	}
}
