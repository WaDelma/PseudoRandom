using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip onHit;
	public AudioClip onAttack;
	public AudioClip repeatingClip;
	public float repeatRate = 5f;
	
	private float lastRepeatPlayTime = float.MinValue;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(repeatingClip != null && Time.time - lastRepeatPlayTime > repeatRate) {
			lastRepeatPlayTime = Time.time;
			AudioSource.PlayClipAtPoint(repeatingClip, transform.position);
		}
	}
	
	public void OnHit() {
		if(onHit != null) AudioSource.PlayClipAtPoint(onHit, transform.position);
	}
	
	public void OnAttack() {
		if(onAttack != null) AudioSource.PlayClipAtPoint(onAttack, transform.position);
	}
	
}
