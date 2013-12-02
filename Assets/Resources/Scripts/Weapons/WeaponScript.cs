using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
	
	public string weaponName = "ultimate weapon";
	public int damage = 20;
	public int ammoCount = 10;
	public int clipSize = 10;
	public float distance = 100.0f;
	public float reloadTime = 2.0f;
	public float firingSpeed = 0.1f;
	public bool automaticFire = false;
	public Vector3 muzzlePosition;
	public GameObject projectilePrefab;
	public GameObject bulletTrailPrefab;
	public AudioClip firingSound;
	public AudioClip reloadSound;
	protected float lastFiringTime;
	private bool firing = false;

	
	// Use this for initialization
	void Start ()
	{
		transform.localRotation = Quaternion.Euler(0.0f, 250.0f, 163.0f);
	}
	
	// Update is called once per frame
	public void Update ()
	{
		if (this.gameObject.tag == "Equipped") {
			if (Input.GetButtonDown ("Fire1"))
				firing = true;
			if (firing && Time.time - lastFiringTime > firingSpeed)
				Fire ();
			if (!automaticFire || Input.GetButtonUp ("Fire1"))
				firing = false;
		}
	}
	
	protected virtual void Fire ()
	{
		lastFiringTime = Time.time;
		AudioSource.PlayClipAtPoint (firingSound, transform.position);
	}
	
	protected virtual void Reload ()
	{
		
	}
	
	protected void Hit (Transform target)
	{
		if (target.tag == "Enemy") {
			target.GetComponent<Health> ().TakeDamage (damage);
		}
	}
	
	protected void CreateBulletTrail (Vector3 target)
	{
		GameObject bulletTrail = (GameObject)Instantiate (bulletTrailPrefab);
		LineRenderer line = bulletTrail.GetComponent<LineRenderer> ();
		line.SetVertexCount (2);
		line.SetPosition (0, transform.TransformPoint (muzzlePosition));
		line.SetPosition (1, target);
	}
	

}
