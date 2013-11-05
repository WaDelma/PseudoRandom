using UnityEngine;
using System.Collections;
using System.Collections.Generic;




// Actual inventory of the player
public class Inventory : MonoBehaviour
{

	private ArrayList items;
	
	void Start ()
	{
		items = new ArrayList ();
		items.Add (new ItemInfo ("roskaa"));
		items.Add (new ItemInfo ("lisaaroskaa"));
	}
	

	void Update ()
	{

	}
	
	public ArrayList getItems ()
	{
		return items;
	}
	
	public void OnTriggerEnter (Collider other)
	{	
		// Collectible items ara added to inventory
		if (other.gameObject.tag == "Collectible") {
			other.gameObject.SetActive (false);
			ItemInfoScript infoS = (ItemInfoScript) other.gameObject.GetComponent(typeof(ItemInfoScript));
			items.Add(infoS.getItemInfo());
		}
	}
	
	
}
