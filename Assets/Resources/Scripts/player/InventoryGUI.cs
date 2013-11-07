		using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

// Encapsulated GUI representation of the inventory, press TAB to open
public class InventoryGUI : MonoBehaviour
{
	private bool inventoryOn = false;
	public Inventory inventory;
	
	public int inventoryWidthDeduction;
	public int inventoryHeightDeduction;
	
	private int invW;
	private int invH;
	private int rows;
	private int cols;
	private int padding = 10;
	public GUIStyle slotStyle;
	
	
	// Use this for initialization
	void Start ()
	{
		this.rows = inventory.inventoryRows;
		this.cols = inventory.inventoryColums;
		this.invW = Screen.width - inventoryWidthDeduction;
		this.invH = Screen.height - inventoryHeightDeduction;
		
		
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
		slotStyle = new GUIStyle (GUI.skin.button);
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
					GUIContent itemContent = new GUIContent (itemI.itemName + "\n x " + itemI.getAmount(), itemI.description);
					
					
					setStyle (itemI);

					
					GUI.Button (new Rect (j * slotW + padding, i * slotH + padding, slotW - padding, slotH - padding), itemContent, slotStyle);
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
	
	private void setStyle (ItemInfo itemI)
	{
		
		slotStyle.normal.background = itemI.icon;
		slotStyle.hover.background = itemI.icon;
		slotStyle.active.background = itemI.icon;
					
		slotStyle.normal.textColor = new Color(0.2F, 0.2F, 0.2F, 1F);
		slotStyle.hover.textColor = new Color(0.1F, 0.1F, 0.1F, 1F);
		slotStyle.active.textColor = Color.black;
	}

}
