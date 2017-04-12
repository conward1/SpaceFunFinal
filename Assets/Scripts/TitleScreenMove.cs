using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenMove : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private bool left = false;
	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.AddForce(new Vector2(30f, 0f));
	}
	void OnTriggerEnter2D(Collider2D background){
		if (background.gameObject.CompareTag ("background")) 
		{
			if (left) {
				rigidBody.AddForce (new Vector2 (30f, 0f));
				rigidBody.AddForce (new Vector2 (30f, 0f));
				left = false;
			} 
			else 
			{
				rigidBody.AddForce(new Vector2(-30f, 0f));
				rigidBody.AddForce(new Vector2(-30f, 0f));
				left = true;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//rigidBody.AddForce(new Vector2(20f, 40f));

	}
}
