using UnityEngine;
using System.Collections;

public class AreaSpawner : MonoBehaviour {
	
	public float sizeX = 10.0f;
	public float sizeY = 0.0f;
	public float sizeZ = 10.0f;
	public float spawnRate = 1.0f;
	public bool randomRotation = true;
	public bool randomTorque = false;
	public GameObject type;
	
	private float lastSpawnTime = 0.0f;
	private int torqueMacig = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastSpawnTime > spawnRate) {
			GameObject newObject;
			Vector3 position = (new Vector3(Random.Range(0, sizeX), Random.Range(0, sizeY), Random.Range(0, sizeZ))) + transform.position;
			Quaternion rotation = randomRotation ? new Quaternion(Random.value, Random.value, Random.value, Random.value) : new Quaternion(0, 0, 0, 0);
			newObject = (GameObject) Instantiate(type, position, rotation);
			if(randomTorque) newObject.rigidbody.AddTorque(Random.value * torqueMacig, Random.value * torqueMacig, Random.value * torqueMacig);
			lastSpawnTime = Time.time;
		}
	}
}
