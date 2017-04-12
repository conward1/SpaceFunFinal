using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPluto : MonoBehaviour {

	private Rigidbody2D rigidBody;
	// Use this for initialization
	void Awake () {

		rigidBody = GetComponent<Rigidbody2D>();

	}

	void OnTriggerEnter2D(Collider2D carl){

		if (carl.gameObject.CompareTag ("Player")) 
		{
			carl.GetComponent<SpriteRenderer>().enabled = true;
			//carl.gameObject.SetActive (true);
		}


	}
	// Update is called once per frame
	void Update () {
		rigidBody.AddForce(new Vector2(20f,0f));	
	}
}
