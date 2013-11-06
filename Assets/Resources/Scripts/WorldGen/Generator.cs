using System;
using UnityEngine;
using UnityEditor;

public abstract class Generator : MonoBehaviour
{
	public static Vector3 units = new Vector3 (1.6f, 1.0f, 1.6f);
	private static GameObject gameO = null;
		
	public void Delete ()
	{
		while (transform.childCount > 0) {
			DestroyImmediate (transform.GetChild (0).gameObject);
		}
	}
	
	public GameObject Create (GameObject obj, Vector3 pos, Quaternion nion)
	{
		GameObject result = (GameObject)Instantiate (obj, pos, nion);
		result.transform.parent = this.transform;
		return result;
	}
	
	public T  Create <T> (Vector3 pos) where T: Component
	{
		if(gameO == null){
			gameO = new GameObject();	
		}
		GameObject gameObject = (GameObject)Instantiate (gameO, pos, Quaternion.identity);
		gameObject.transform.parent = this.transform;
		T result = gameObject.AddComponent<T>();
		gameObject.name = result.ToString();
		return result;
	}
		
	public abstract void Generate ();
}


