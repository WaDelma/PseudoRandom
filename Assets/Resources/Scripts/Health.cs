using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int maxHealth = 100;
	public GameObject asdf;
	public AudioClip deathSound;
	
	private int health;
	private bool dead = false;
	
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(int damage) {
		health -= damage;
		if(health < 0 && !dead) Dead();
	}
	
	private void Dead() {
		if(dead) return;
		dead = true;
		for(int i = 0; i < 10; i++) {
			Instantiate(asdf, transform.position, new Quaternion(0, 0, 0, 0));
		}
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		gameObject.SendMessage("Die");
		Destroy(transform.gameObject);
	}
}
