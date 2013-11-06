using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {
	
	public float speed = 100.0f;
	public float attackRate = 1.0f;
	public float attackDistance = 0.5f;
	public int damage = 10;

	public Animation idle;
	public Animation walk;
	public Animation attack;
	
	private CharacterController controller;
	private float lastAttackTime;
	private float rotationSpeed = 3f;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Move(Vector3 direction) {
		direction.y = transform.position.y;
		direction.Normalize();
		SmoothRotate(direction);
		controller.SimpleMove(direction * speed * Time.deltaTime);
	}
	
	public void SmoothRotate(Vector3 direction) {
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), rotationSpeed * Time.deltaTime);
	}
	
	public void Attack(GameObject target) {
		bool withinDistance = Vector3.Distance(transform.position, target.transform.position) < attackDistance;
		Health healthComponent = target.GetComponent<Health>();
		if(healthComponent != null && withinDistance && (Time.time - lastAttackTime) < attackRate) {
			healthComponent.TakeDamage(damage);
			target.SendMessage("onHit");
		}
	}
}
