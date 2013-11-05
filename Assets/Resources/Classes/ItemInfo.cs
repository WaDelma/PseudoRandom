using UnityEngine;
using System.Collections;


// Generic class on which to build different game items
public class ItemInfo : MonoBehaviour {
	
	// Item name
	public string name;
	
	// Item ID
	public int id;
	
	// Item icon
	public Texture2D icon;
	
	// Add other info here, weight etc

	public ItemInfo(string name) {
		this.name = name;
		
	}
	
	
}
