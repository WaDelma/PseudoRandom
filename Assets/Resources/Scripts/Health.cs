using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int maxHealth = 100;
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
		if(health < 0 && !dead) OnDeath();
	}
	
	private void OnDeath() {
		if(dead) return;
		dead = true;
		if(deathSound != null) {
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
		}
		gameObject.SendMessage("OnDeath");
		Destroy(transform.gameObject);
	}
}
