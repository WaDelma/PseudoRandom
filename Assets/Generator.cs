using System;
using UnityEngine;
using UnityEditor;

public abstract class Generator : MonoBehaviour
{
	public static Vector2 units = new Vector2 (1.6f, 1.0f);
		
	public void Delete ()
	{
		while (transform.childCount > 0) {
			DestroyImmediate (transform.GetChild (0).gameObject);
		}
	}
	
	public GameObject Create (GameObject obj, Vector3 pos, Quaternion nion)
	{
		GameObject result = ((GameObject)Instantiate (obj, pos, nion));
		result.transform.parent = this.transform;
		return result;
	}
		
	public abstract void Generate ();
}


