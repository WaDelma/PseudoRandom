using UnityEngine;
using System.Collections;



// ALL ITEMS HAVE TO HAVE THIS SCRIPT IN ORDER FOR THEM TO BE IN THE INVENTORY (aka wannabe interface)
public class ItemInfoScript : MonoBehaviour {
	private ItemInfo info;
	public string itemName;
	public Texture2D icon;
	public string description;
	public int amount;
	public GameObject gObject;
	public bool isWeapon;


	
	// Use this for initialization
	void Start () {
		info = new ItemInfo(itemName, icon, description, amount, gObject, isWeapon);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public ItemInfo getItemInfo() {
		return info;
	}
	

}
