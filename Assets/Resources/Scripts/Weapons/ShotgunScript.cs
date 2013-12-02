using UnityEngine;
using System.Collections;

public class ShotgunScript : WeaponScript
{
	public int shots = 20;
	public float spread = 20.0f; //spreading angle
	
	protected override void Fire ()
	{
		base.Fire ();
		Debug.Log("fire");
		
		for(int i = 0; i < shots; i++) {
			Vector3 direction = transform.forward;
			RaycastHit hit;
			direction = Utils.RotateX (direction, Random.Range (spread / -2, spread / 2));
			direction = Utils.RotateY (direction, Random.Range (spread / -2, spread / 2));
			direction = Utils.RotateZ (direction, Random.Range (spread / -2, spread / 2));
			
			Ray ray = new Ray (transform.TransformPoint (muzzlePosition), direction);
			if (Physics.Raycast (ray, out hit, distance)) {
				CreateBulletTrail (hit.point);
				Hit (hit.transform);
			} else {
				CreateBulletTrail ((direction * distance) + transform.TransformPoint (muzzlePosition));
			}
		}
	}
	

	
}
