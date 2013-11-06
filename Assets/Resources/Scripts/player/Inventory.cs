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
	private GameObject equippedWeapon;
	
	void Start ()
	{
		inventorySize = inventoryColums * inventoryRows;
		items = initInventoriList ();
		equippedWeapon = null;

	}

	void Update ()
	{

	}
	
	public List<ItemInfo> getItems ()
	{
		return items;	
	}
	
	public void OnTriggerEnter (Collider other)
	{	
		// Collectible items ara added to inventory
		if (other.gameObject.tag == "Collectible") {
			other.gameObject.SetActive(false);
			ItemInfoScript infoS = (ItemInfoScript)other.gameObject.GetComponent (typeof(ItemInfoScript));
			ItemInfo itemI = infoS.getItemInfo ();
			
			if (!items.Contains (itemI)) {
				items [slotI (nextEmpty.getRow (), nextEmpty.getCol ())] = itemI;
				updateNextEmptySlot ();
			} else {
				ItemInfo inventoryItem = items.Find (x => x.name == itemI.name);
				Debug.Log(inventoryItem.getAmount());
				inventoryItem.increaseAmountBy (itemI.getAmount());
				Debug.Log(inventoryItem.getAmount());

			}

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
	
	private void debugList ()
	{
		for (int i = 0; i < inventoryRows; i++) {
			Debug.Log (items [i].ToString ());
		}
	}
	
	private int slotI (int row, int col)
	{
		return (row * inventoryRows) + col;
	}
	
	public GameObject getEquippedWeapon ()
	{
		return equippedWeapon;
	}
}
