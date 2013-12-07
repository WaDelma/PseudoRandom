using UnityEngine;
using System.Collections;

// Generic class on which to build different game items
public class ItemInfo {
	
	// Item name
	public string itemName;
	
	// Item ID
	public int id;
	
	// Item icon
	public Texture2D icon;
	
	// Item description 
	public string description;
	
	// Item amount
	private int amount;
	
	// Game object this info is attached to
	public GameObject gObject;
	
	// Is this item a weapon
	public bool isWeapon;
	
	
	// Add other info here, weight etc

	public ItemInfo (string itemName, Texture2D icon, string description, int amount, GameObject gObject, bool isWeapon)
	{
		this.itemName = itemName;
		this.icon = icon;
		this.description = description;
		this.amount = amount;
		this.gObject = gObject;
		this.isWeapon = isWeapon;
	}

	public void increaseAmountBy (int amount) {
		Debug.Log (amount);
		this.amount = this.amount + amount;
	}
	
	public bool decreaseAmountBy (int amount) {
		Debug.Log (amount);
		if (this.amount < amount) {
			return false;
		} 
		this.amount = this.amount - amount;
		return true;
	}
		
	public int getAmount () {
		return this.amount;
	}
	
	public override bool Equals (object obj) {
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(ItemInfo))
			return false;
		ItemInfo other = (ItemInfo)obj;
		return itemName == other.itemName;
	}

	public override int GetHashCode () {
		unchecked {
			return (itemName != null ? itemName.GetHashCode () : 0);
		}
	}

}