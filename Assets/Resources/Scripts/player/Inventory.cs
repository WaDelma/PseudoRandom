using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Actual inventory of the player
public class Inventory : MonoBehaviour {
	public int inventoryColums;
	public int inventoryRows;
	private int inventorySize;
	private List<ItemInfo> items;
	private Slot nextEmpty;
	
	void Start () {
		inventorySize = inventoryColums * inventoryRows;
		items = initInventoriList ();
		
	}

	void Update () {

	}
	
	public List<ItemInfo> getItems () {
		return items;	
	}
	
	// PICKING UP AN ITEM
	public void OnTriggerEnter (Collider other) {	
		tryAddingItemToInventory (other);
	}
	
	private List<ItemInfo> initInventoriList () {
		List<ItemInfo> inv = new List<ItemInfo> (inventorySize);
		for (int i = 0; i < inventorySize; i++) {
			inv.Add (null);
		}
		this.nextEmpty = new Slot (0, 0);
		return inv;
	}
	
	private void updateNextEmptySlot () {
		for (int i = 0; i < inventoryRows; i++) {
			for (int j = 0; j < inventoryColums; j++) {
				if (items [slotI (i, j)] == null) {
					nextEmpty.setRowAndCol (i, j);
					return;
				}	
			}
		}
		
	}
	
	private int slotI (int row, int col) {
		return (row * inventoryRows) + col;
	}
		
	private void tryAddingItemToInventory (Collider other) {
		
		if (other.gameObject.tag == "Collectible") {
			ItemInfo itmInf = getColliderObjectItemInfo (other);
			
			if (!items.Contains (itmInf)) {
				addItemToNewInventorySlot (itmInf);
			} else {
				increaseItemCountInInventory (itmInf);	
			}
			other.gameObject.SetActive (false);
			//	Destroy (other.gameObject);
		}
	}
	
	private ItemInfo getColliderObjectItemInfo (Collider other) {
		ItemInfoScript infoS = (ItemInfoScript)other.gameObject.GetComponent (typeof(ItemInfoScript));
		return infoS.getItemInfo ();
	}
	
	private bool addItemToNewInventorySlot (ItemInfo itmInf) {
		items [slotI (nextEmpty.getRow (), nextEmpty.getCol ())] = itmInf;
		updateNextEmptySlot ();
		return true;
	}
	
	private bool increaseItemCountInInventory (ItemInfo itmInf) {
		ItemInfo inventoryItem = items.Find (x => x.itemName == itmInf.itemName);
		Debug.Log (inventoryItem.getAmount ());
		inventoryItem.increaseAmountBy (itmInf.getAmount ());
		Debug.Log (inventoryItem.getAmount ());
		return true;
	}
		
	public bool decreaseItemCountInInventoryByOne (ItemInfo itmInf) {
		ItemInfo inventoryItem = items.Find (x => x.itemName == itmInf.itemName);
		Debug.Log (inventoryItem.getAmount ());
		bool errorInDecrease = inventoryItem.decreaseAmountBy (1);
		if(inventoryItem.getAmount() < 1) {
			removeItemFromInventoryList(inventoryItem);
		}
		
		Debug.Log (inventoryItem.getAmount ());
		return errorInDecrease;
	}
	
	private void removeItemFromInventoryList(ItemInfo inventoryItem) {
		if (!items.Contains(inventoryItem)) {
			Debug.LogError("Trying to remove item thats not in the item list: " + inventoryItem.itemName);
			return;
		}
		items.Remove(inventoryItem);
		items.Add(null);
		updateNextEmptySlot();
	}
}
