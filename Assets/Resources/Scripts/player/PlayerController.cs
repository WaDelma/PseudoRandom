using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	
	public float walkingSpeed = 3.0f;
	public float rotationSpeed = 200.0f;
	public float jumpSpeed = 1.0f;
	public float gravity = 10.0f;
	public GameObject towerPrefab;
	//public Inventory inventory;
	
	public AnimationClip walk;
	public AnimationClip idle;
	public AnimationClip aim;
	public AnimationClip kick;
	
	public Inventory inventory;
	
	private CharacterController controller;
	private Animation animation;
	private Transform weaponHand;
	private GameObject currentWeapon;
	private Vector3 movement;
	private bool buildingInProgress = false;
	
	
	public const float UNIT = 1.6f;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		weaponHand = transform.Find("player/Armature/root/stomach/upper_arm_R/lower_arm_R/hand_R/WeaponHand");
		//SwitchWeapon((GameObject) Resources.Load("Prefabs/Weapons/Shotgun"));
		movement = new Vector3();
		
		InitAnimations();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement();
		PlayerAnimation();
		WeaponControl();
	}

	
	private void InitAnimations() {
		animation = GetComponentInChildren<Animation>();
		animation.AddClip(walk, "Walk");
		animation.AddClip(aim, "Aim");
		animation.AddClip(kick, "Kick");
		animation["Walk"].layer = 0;
		animation["Aim"].layer = 1;
		animation["Aim"].AddMixingTransform(transform.Find("player/Armature/root/stomach/upper_arm_L"));
		animation["Aim"].AddMixingTransform(transform.Find("player/Armature/root/stomach/upper_arm_R"));
		animation["Kick"].AddMixingTransform(transform.Find("player/Armature/root/stomach/upper_leg_R"));
		animation.wrapMode = WrapMode.Loop;
		
	}
	
	private void PlayerMovement() {
		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);
		movement = new Vector3(0, movement.y, 0);
		movement += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
		movement += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * walkingSpeed;
		if(Input.GetButtonDown("Jump")) Jump();
		movement.y -= gravity * Time.deltaTime;
		controller.Move(movement);
	}
	

private void Jump() {
		if(controller.isGrounded) {
			movement.y = jumpSpeed;
		}
	}
	
	public void PlayerAnimation() {	
		animation.CrossFade("Aim");
		animation.CrossFade("Walk");
	}
	
	private void WeaponControl() {
		if(inventory.hasWeapon()){
			GameObject bestWeapon = inventory.getBestWeapon();
			SwitchWeapon(bestWeapon);
		}
	}	
	
	public void Build(Object building) {
		buildingInProgress = true;
		if(currentWeapon != null) currentWeapon.GetComponent<WeaponScript>().enabled = false;
	}
	
	public void BuildComplete() {
		buildingInProgress = false;
		if(currentWeapon != null) currentWeapon.GetComponent<WeaponScript>().enabled = true;
	}
	
	private void SwitchWeapon(GameObject newWeapon) {
		if(currentWeapon != null) Destroy(currentWeapon);
		currentWeapon = (GameObject) Instantiate(newWeapon);
		currentWeapon.tag = "Equipped";
		currentWeapon.transform.parent = weaponHand;
		currentWeapon.transform.localPosition = Vector3.zero;
		weaponHand.transform.localPosition = Vector3.zero;
	}
	
	public Inventory getInventory ()
	{
		return inventory;
	}
	
}
