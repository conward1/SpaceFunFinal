using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMover : MonoBehaviour {

	Rigidbody2D rigidBody;
	bool stop = false;
	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (!stop) 
		{
			rigidBody.AddForce(new Vector2(5f, 0f));
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("background"))
		{
			rigidBody.Sleep();
			stop = true;
		}
	}
}
