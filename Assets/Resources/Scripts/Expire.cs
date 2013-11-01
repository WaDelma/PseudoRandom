using UnityEngine;
using System.Collections;

/*
 * Destoys the GameObject after sertain amount of time
 */
public class Expire : MonoBehaviour {

	public float lifeTime = 1.0f; //total life time in seconds
	
	private float delta = 0;
	
	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime;
		if(delta > lifeTime) Destroy(transform.gameObject);
	}
}
