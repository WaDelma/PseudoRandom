		using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

// Encapsulated GUI representation of the inventory, press TAB to open
public class InventoryGUI : MonoBehaviour {
	private bool inventoryOn = false;
	public Inventory inventory;
	public int inventoryWidthDeduction;
	public int inventoryHeightDeduction;
	public int padding;
	private int invW;
	private int invH;
	private int rows;
	private int cols;
	public GUIStyle slotStyle;
	
	void Start () {
		initInventoryDimensions ();
	}
	
	void Update () {
		toggleInventoryCheck ();
	}

	void OnGUI () {
		createInventoryGUI ();
	}
	
	private void initInventoryDimensions () {
		this.rows = inventory.inventoryRows;
		this.cols = inventory.inventoryColums;
		this.invW = Screen.width - inventoryWidthDeduction;
		this.invH = Screen.height - inventoryHeightDeduction;
	}
	
	private void toggleInventoryCheck () {
		if (Input.GetKeyUp (KeyCode.Tab)) {
			if (inventoryOn) {
				inventoryOn = false;
			} else if (!inventoryOn) {
				inventoryOn = true;
			}
		}
	}
	
	private void createInventoryGUI () {
		slotStyle = new GUIStyle (GUI.skin.button);
		if (inventoryOn) {
			GUI.BeginGroup (new Rect (80, 50, invW, invH));

			// Main inventory frame
			GUI.Box (new Rect (0, 0, invW, invH), "");
			drawInventorySlots ();

			GUI.EndGroup ();
		}
	}

	private void drawInventorySlots () {
		int slotW = (invW - padding) / cols;
		int slotH = (invH - padding) / rows;
		
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {

				if (inventory.getItems () [slotInd (i, j)] != null) {
					drawSlotWithItem (i, j, slotW, slotH);	
				} else {
					// Draw an empty slot
					GUI.Box (new Rect (j * slotW + padding, i * slotH + padding, slotW - padding, slotH - padding), "");
				}
				
			}
		}
	}
	
	private void drawSlotWithItem (int row, int col, int slotW, int slotH) {
		ItemInfo itmInf = inventory.getItems () [slotInd (row, col)];
		GUIContent itemContent = new GUIContent (itmInf.itemName + "\n x " + itmInf.getAmount (), itmInf.description);
		setStyle (itmInf);	// Edit inventory slot text colors etc.
		if (GUI.Button (createSlotRect (row, col, slotW, slotH), itemContent, slotStyle)) {
			itemButtonLogic(itmInf);
		}				
	}
	
	private void setStyle (ItemInfo itemI) {
		slotStyle.normal.background = itemI.icon;
		slotStyle.hover.background = itemI.icon;
		slotStyle.active.background = itemI.icon;
					
		slotStyle.normal.textColor = new Color (0.2F, 0.2F, 0.2F, 1F);
		slotStyle.hover.textColor = new Color (0.1F, 0.1F, 0.1F, 1F);
		slotStyle.active.textColor = Color.black;
	}
		
	private int slotInd (int row, int col) {
		return (row * rows) + col;
	}
	
	private Rect createSlotRect (int row, int col, int slotW, int slotH) {
		return new Rect (col * slotW + padding, row * slotH + padding, slotW - padding, slotH - padding);
	}
	
	private void itemButtonLogic(ItemInfo clickedItem) {
		Debug.Log(clickedItem.itemName);
		this.gameObject.SendMessage("Build", clickedItem);
	}
	
	public void BuildComplete(ItemInfo itmInf) {
		this.inventory.decreaseItemCountInInventoryByOne(itmInf);
	}
}
