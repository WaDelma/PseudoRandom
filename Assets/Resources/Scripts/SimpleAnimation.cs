using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class SimpleAnimation : MonoBehaviour {
	
	public AnimationClip animationClip;
	public float speed = 1f;
	
	private Animation animation;
	
	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation>();
		animation.AddClip(animationClip, "animationClip");
		animation["animationClip"].speed = speed;
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		animation.CrossFade("animationClip");
	}
}
