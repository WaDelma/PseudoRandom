using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	
	public float speed = 100.0f;
	public float rotationSpeed = 50.0f;
	
	private CharacterController controller;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Move(Vector3 direction) {
		direction.Normalize();
		RotateTowards(direction);
		controller.SimpleMove(direction * speed * Time.deltaTime);
	}
	
	public void RotateTowards(Vector3 target) {
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target, Vector3.up), rotationSpeed);
	}
}
