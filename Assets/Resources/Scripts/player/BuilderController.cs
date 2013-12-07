using UnityEngine;
using System.Collections;

public class BuilderController : MonoBehaviour {
	
	private bool buildingInProgress;
	private GameObject building;
	private Tower tower;
	private float unit = 1.6f;
	
	public GameObject testObject;
	
	// Use this for initialization
	void Start () {
		//SendMessage("Build", testObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(buildingInProgress) BuildProgress();
	}
	
	public void Build(Object newBuilding) {
		buildingInProgress = true;
		building = (GameObject) Instantiate(newBuilding);
		building.collider.isTrigger = true;
		tower = building.GetComponent<Tower>();
		if(tower != null) tower.enabled = false;
	}
	
	private void BuildProgress() {
		Vector3 position = transform.position + (transform.forward * unit);
		position = Utils.Snap(position, unit);
		position.x += unit / 2;
		position.z += unit / 2;
		position.y = 0;
		building.transform.position = position;
		if(Input.GetButtonDown("Fire1")) PlaceBuilding();
	}
	
	private void PlaceBuilding() {
		buildingInProgress = false;
		building.collider.isTrigger = false;
		if(tower != null) tower.enabled = true;
		tower = null;
		SendMessage("BuildComplete");
	}
}
