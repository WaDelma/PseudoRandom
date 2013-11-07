using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Actual inventory of the player
public class Inventory : MonoBehaviour
{
	public int inventoryColums;
	public int inventoryRows;
	private int inventorySize;
	private List<ItemInfo> items;
	private Slot nextEmpty;
	private bool containsWeapon = false;
	
	void Start ()
	{
		inventorySize = inventoryColums * inventoryRows;
		items = initInventoriList ();
		
	}

	void Update ()
	{

	}
	
	public List<ItemInfo> getItems ()
	{
		return items;	
	}
	
	// PICKING UP AN ITEM
	public void OnTriggerEnter (Collider other)
	{	
		// Collectible items ara added to inventory
		if (other.gameObject.tag == "Collectible") {
			
			ItemInfoScript infoS = (ItemInfoScript)other.gameObject.GetComponent (typeof(ItemInfoScript));
			ItemInfo itemI = infoS.getItemInfo ();
			
			if(itemI.isWeapon) containsWeapon = true;
			
			if (!items.Contains (itemI)) {
				items [slotI (nextEmpty.getRow (), nextEmpty.getCol ())] = itemI;
				updateNextEmptySlot ();
			} else {
				ItemInfo inventoryItem = items.Find (x => x.itemName == itemI.itemName);
				Debug.Log(inventoryItem.getAmount());
				inventoryItem.increaseAmountBy (itemI.getAmount());
				Debug.Log(inventoryItem.getAmount());

			}
			Destroy(other.gameObject);
		}
	}
	
	private List<ItemInfo> initInventoriList ()
	{
		List<ItemInfo> inv = new List<ItemInfo> (inventorySize);
		for (int i = 0; i < inventorySize; i++) {

			inv.Add (null);

		}
		this.nextEmpty = new Slot (0, 0);
		return inv;
	}
	
	private void updateNextEmptySlot ()
	{
		for (int i = 0; i < inventoryRows; i++) {
			for (int j = 0; j < inventoryColums; j++) {
				if (items [slotI (i, j)] == null) {
					nextEmpty.setRowAndCol (i, j);
					return;
				}	
			}
		}
		
	}
	
	
	private int slotI (int row, int col)
	{
		return (row * inventoryRows) + col;
	}
	
	
	public bool hasWeapon(){
		return containsWeapon;
	}
	
	public GameObject getBestWeapon(){
		ItemInfo weapon = items.Find (x => x.itemName == "SHOTGUN");
		return weapon.gObject;
	}
}
