using UnityEngine;
using System.Collections;

public class BuilderController : MonoBehaviour {
	
	private bool buildingInProgress;
	private GameObject building;
	private float unit = 1.6f;
	private ItemInfo placableItmInf;


	
	void Start () {
		//SendMessage("Build", testObject);
	}
	

	void Update () {
		if (buildingInProgress)
			BuildProgress ();
	}
	
	public void Build (ItemInfo itmInf) {
		this.placableItmInf = itmInf;
		buildingInProgress = true;
		building = (GameObject)Instantiate (placableItmInf.gObject);
		building.collider.isTrigger = true;
		itemSpecificOptionsWhenPlacing ();
		if (buildingInProgress)
			BuildProgress ();
	}
	
	private void BuildProgress () {
		Vector3 position = transform.position + (transform.forward * unit);
		building.SetActive (true);
		position = Utils.Snap (position, unit);
		position.x += unit / 2;
		position.z += unit / 2;
		position.y = -3.782156f;
		building.transform.position = position;

		if (Input.GetButtonDown ("Fire1"))
			PlaceBuilding ();
	}
	
	private void PlaceBuilding () {
		buildingInProgress = false;
		building.collider.isTrigger = false;

		itemSpecificOptionsAfterPlacing ();
		
		SendMessage ("BuildComplete", this.placableItmInf);		
		this.placableItmInf = null;
	}
	
	private void itemSpecificOptionsWhenPlacing () {
		if (placableItmInf.itemName == "Tower") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = false;
		}
	}

	private void itemSpecificOptionsAfterPlacing () {
		if (placableItmInf.itemName == "Tower") {
			Tower tower = building.GetComponent<Tower> ();
			if (tower != null)
				tower.enabled = true;
		} else if (placableItmInf.itemName == "MEAT") {
			building.collider.isTrigger = true;
		} else if (placableItmInf.itemName == "DUCT TAPE") {
			building.collider.isTrigger = true;
		}
	
	}
	
}
