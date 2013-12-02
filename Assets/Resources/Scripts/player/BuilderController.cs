using UnityEngine;
using System.Collections;

public class BuilderController : MonoBehaviour {
	
	private bool active;
	private GameObject building;
	private Tower tower;
	private float unit = 1.6f;
	
	public GameObject testTower;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(active) BuildProgress();
	}
	
	public void Build(Object newBuilding) {
		active = true;
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
		tower.transform.position = position;
		if(Input.GetButtonDown("Fire1")) PlaceBuilding();
	}
	
	private void PlaceBuilding() {
		active = false;
		building.collider.isTrigger = false;
		if(tower != null) tower.enabled = true;
		tower = null;
		SendMessage("BuildComplete");
	}
}
