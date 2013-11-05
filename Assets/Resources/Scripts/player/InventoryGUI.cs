using UnityEngine;
using System.Collections;
using System.Text;




// Encapsulated GUI representation of the inventory, press TAB to open
public class InventoryGUI : MonoBehaviour
{
	private bool inventoryOn = false;
	public Inventory inventory;
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		// Turn Inventory on or off
		if (Input.GetKeyUp (KeyCode.Tab)) {
			if (inventoryOn) {
				inventoryOn = false;
			} else if (!inventoryOn) {
				inventoryOn = true;
			}
		}
		
		

	}

	void OnGUI ()
	{
		if (inventoryOn) {
			GUI.Box (new Rect (80, 50, Screen.width - 160, Screen.height - 100), printInventoryItems());
		}
	}
	
	
	private string printInventoryItems() {
		StringBuilder sb = new StringBuilder();
		ArrayList list = inventory.getItems();
		foreach (ItemInfo item in list) {
			sb.Append(item.name + "\n");
		}
		return sb.ToString();
	}
	
}
