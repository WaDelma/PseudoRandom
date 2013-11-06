using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

// Encapsulated GUI representation of the inventory, press TAB to open
public class InventoryGUI : MonoBehaviour
{
	private bool inventoryOn = false;
	public Inventory inventory;
	private int invW = Screen.width - 460;
	private int invH = Screen.height - 400;
	private int rows;
	private int cols;
	private int padding = 10;
	public GUIStyle slotStyle;
	
	
	// Use this for initialization
	void Start ()
	{
		this.rows = inventory.inventoryRows;
		this.cols = inventory.inventoryColums;
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
			GUI.BeginGroup (new Rect (80, 50, invW, invH));
			// Main inventory frame
			GUI.Box (new Rect (0, 0, invW, invH), "");
			

			
			drawInventorySlots ();


			
			GUI.EndGroup ();
		}
	}
	
	private void drawInventorySlots ()
	{
		int slotW = (invW - padding) / cols;
		int slotH = (invH - padding) / rows;
		
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {

				if (inventory.getItems () [slotInd (i, j)] != null) {
					ItemInfo itemI = inventory.getItems () [slotInd (i, j)];
					GUIContent itemContent = new GUIContent (itemI.name + " x " + itemI.amount, itemI.icon, itemI.description);
					GUI.Box (new Rect (j * slotW + padding, i * slotH + padding, slotW - padding, slotH - padding), itemContent, slotStyle);
				} else {
					GUI.Box (new Rect (j * slotW + padding, i * slotH + padding, slotW - padding, slotH - padding), "");
				}
				
				
				
			}
		}
	}
	
	private int slotInd (int row, int col)
	{
		return (row * rows) + col;
	}
}
