using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	
	public string weaponName = "ultimate weapon";
	public int damage = 20;
	public int ammoCount = 10;
	public int clipSize = 10;
	public float reloadTime = 2.0f;
	public float firingSpeed = 0.1f;
	public bool automaticFire = false;
	public GameObject projectilePrefab;
	public GameObject bulletTrailPrefab;
	
	private float lastFiringTime;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}
	
	public void Fire() {
		
	}
	
	public void Reload() {
		
	}
}
