using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeilMover : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator animate;
	bool rotate = true;
	// Use this for initialization
	void Awake () 
	{
		rigidBody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rotate)
		{
			transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
			rigidBody.AddForce (new Vector2 (-.2f, 0f));
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		rotate = false;
		//rigidBody.AddForce (new Vector2 (2f, 0f));
		rigidBody.Sleep();
	}
}
