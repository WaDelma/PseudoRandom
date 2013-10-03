using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float walkingSpeed = 10.0f;
	public float rotationSpeed = 200.0f;
	//public Inventory inventory;
	
	private Transform weaponHand;
	private GameObject currentWeapon;
	
	// Use this for initialization
	void Start () {
		weaponHand = transform.Find("Armature/root/stomach/upper_arm_R/lower_arm_R/hand_R/WeaponHand");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement();
		WeaponControl();
	}
	
	private void PlayerMovement() {
		transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
		transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);
	}
	
	private void WeaponControl() {
		
	}
	
	private void SwitchWeapon(GameObject newWeapon) {
		Destroy(currentWeapon);
		currentWeapon = (GameObject) Instantiate(newWeapon);
		currentWeapon.transform.parent = weaponHand;
	}
}
