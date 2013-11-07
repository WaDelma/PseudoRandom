using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public float attackRadius = 5.0f;
	public float attackRate = 1.0f;
	public float damage = 20.0f;
	
	private GameObject target = null;
	private float lastAttackTime = 0.0f;
	private LightningBolt lightningBolt; //TODO: ei näin
	
	// Use this for initialization
	void Start () {
		lightningBolt = transform.GetChild(0).GetComponent<LightningBolt>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastAttackTime > attackRate) Attack();
	}
	
	private void Attack() {
		UpdateTarget();
		if(target == null) return;
		lightningBolt.target = target.transform; //TODO: ei näin
		Health targetHealth = target.GetComponent<Health>();
		if(targetHealth != null) targetHealth.TakeDamage((int) damage);
		lastAttackTime = Time.time;
	}
	
	private void UpdateTarget() {
		if(target == null || Vector3.Distance(transform.position, target.transform.position) > attackRadius) {
			target = ClosestEnemy();
		}
	}
	
	private GameObject ClosestEnemy() {
		Collider[] colliders = Physics.OverlapSphere(transform.position, attackRadius);
		float minDistance = float.MaxValue;
		Collider closestCollider = null;
		foreach(Collider collider in colliders) {
			if(collider.tag != "Enemy") continue;
			float distance = Vector3.Distance(transform.position, collider.transform.position);
			if(distance < minDistance) {
				minDistance = distance;
				closestCollider = collider;
			}
		}
		return closestCollider == null ? null : closestCollider.gameObject;
	}
}
