using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeptuneShip : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private bool left = false;
	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.AddForce(new Vector2(100f, 0f));
	}
	void OnTriggerEnter2D(Collider2D background){
		if (background.gameObject.CompareTag ("background")) 
		{
			if (left) {
				rigidBody.AddForce (new Vector2 (100f, 0f));
				rigidBody.AddForce (new Vector2 (100f, 0f));
				transform.Rotate (new Vector3 (0, 0, 180));
				left = false;
			} 
			else 
			{
				rigidBody.AddForce(new Vector2(-100f, 0f));
				rigidBody.AddForce(new Vector2(-100f, 0f));
				transform.Rotate (new Vector3 (0, 0, 180));
				left = true;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
