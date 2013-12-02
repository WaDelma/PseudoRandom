using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour {
	
	public float waypointSkipDistance = 3.0f;
	public float pathCalculationRate = 0.5f; //rate of recalculation in seconds
	public string targetTag = "Treasure";
	public float attackPlayerTriggerDistance = 5.0f;
	public float attackPlayerUntriggerDistance = 15.0f;
	public float attackDistance = 0.5f;
	
	private EnemyController controller;
	private Seeker seeker;
	private Path path;
	private GameObject closestTreasure;
	private GameObject player;
	private GameObject currentTarget;
	private int currentWaypoint = 0;
	private float lastPathCalculationTime = 0;
	
	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<EnemyController>();
		closestTreasure = ClosestTreasure();
		player = GameObject.FindWithTag("Player");
		currentTarget = closestTreasure;
		
		UpdatePath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void FixedUpdate() {
		if((Time.time - lastPathCalculationTime) > pathCalculationRate) UpdatePath();
		if(path != null && currentWaypoint < path.vectorPath.Count) {
			FollowTarget();
			if(DistanceToNextNode() < waypointSkipDistance) currentWaypoint++;
		}
		Attack();
	}
	
	public void  OnPathComplete(Path path) {
		if(!path.error) {
			this.path = path;
			currentWaypoint = 1;
			lastPathCalculationTime = Time.time;
		}
		else {
			Debug.Log("path error!!!");
		}
	}
	
	private void FollowTarget() {
		Vector3 direction = path.vectorPath[currentWaypoint] - transform.position;
		direction.y = 0;
		controller.Move(direction);
	}
	
	private void Attack() {
		if(currentTarget == null) return;
		float targetDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
		if(targetDistance < attackDistance) controller.Attack(currentTarget);
	}
	
	private void UpdatePath() {
		UpdateTarget();
		if(currentTarget == null) return;
		seeker.StartPath(transform.position, currentTarget.transform.position, OnPathComplete);
		lastPathCalculationTime = float.MaxValue;
	}
	
	private void UpdateTarget() {
		float playerDistance = Vector3.Distance(transform.position, player.transform.position);
		if(playerDistance < attackPlayerTriggerDistance) {
			currentTarget = player;
		}
		else if(currentTarget == player && playerDistance > attackPlayerUntriggerDistance) {
			closestTreasure = ClosestTreasure();
			currentTarget = closestTreasure;
		}
	}
	
	private GameObject ClosestTreasure() {
		GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
		GameObject closestTarget = null;
		float minDistance = float.MaxValue;
		
		foreach(GameObject target in targets) {
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if(distance < minDistance) {
				minDistance = distance;
				closestTarget = target;
			}
		}
		return closestTarget;
	}
	
	private float DistanceToNextNode() {
		return Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
	}
}
