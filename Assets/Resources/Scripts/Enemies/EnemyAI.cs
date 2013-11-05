using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour {
	
	public float nextWaypointDistance = 3.0f;
	public float pathCalculationRate = 0.5f; //rate of recalculation in seconds
	
	private EnemyController controller;
	private Seeker seeker;
	private Path path;
	private GameObject target;
	private int currentWaypoint = 0;
	private float lastPathCalculationTime = 0;
	
	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<EnemyController>();
		target = GameObject.FindWithTag("Player");
		
		CalculatePath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void FixedUpdate() {
		FollowTarget();
		
		if((Time.time - lastPathCalculationTime) > pathCalculationRate) CalculatePath();
	}
	
	private void FollowTarget() {
		if(path == null) return;
		if(currentWaypoint >= path.vectorPath.Count) return;
		
		Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		controller.Move(direction);
		
		if(Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
		}
	}
	
	private void CalculatePath() {
		seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
		lastPathCalculationTime = Time.time;
	}
	
	public void  OnPathComplete(Path path) {
		if(!path.error) {
			this.path = path;
			currentWaypoint = 0;
		}
		else {
			Debug.Log("path error!!!");
		}
	}
}
