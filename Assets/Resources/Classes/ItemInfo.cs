using UnityEngine;
using System.Collections;

// Generic class on which to build different game items
public class ItemInfo
{
	
	// Item name
	public string name;
	
	// Item ID
	public int id;
	
	// Item icon
	public Texture2D icon;
	
	// Item description 
	public string description;
	
	// Item amount
	public int amount;
	
	
	// Add other info here, weight etc

	public ItemInfo (string name, Texture2D icon, string description, int amount)
	{
		this.name = name;
		this.icon = icon;
		this.description = description;
		this.amount = amount;
	}

	public void increaseAmountBy (int amount)
	{
		this.amount += amount;
	}
	
	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(ItemInfo))
			return false;
		ItemInfo other = (ItemInfo)obj;
		return name == other.name;
	}

	public override int GetHashCode ()
	{
		unchecked {
			return (name != null ? name.GetHashCode () : 0);
		}
	}

}