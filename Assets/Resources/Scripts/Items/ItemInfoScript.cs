using UnityEngine;
using System.Collections;



// ALL ITEMS HAVE TO HAVE THIS SCRIPT IN ORDER FOR THEM TO BE IN THE INVENTORY (aka wannabe interface)
public class ItemInfoScript : MonoBehaviour {
	private ItemInfo info;
	public string name;
	public Texture2D icon;
	public string description;
	public int amount;
	public GameObject gObject;
	private bool equipOnPickup;

	
	// Use this for initialization
	void Start () {
		if (this.gameObject.CompareTag("Weapon")){
			equipOnPickup = true;
		} else {
			equipOnPickup = false;
		}
		info = new ItemInfo(name, icon, description, amount, equipOnPickup, gObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public ItemInfo getItemInfo() {
		return info;
	}
	

}
