using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thanks : MonoBehaviour {
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
			rigidBody.AddForce(new Vector2(0f, 1f));
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("background"))
		{
			rigidBody.Sleep();
			stop = true;
			SceneManager.LoadScene ("start", LoadSceneMode.Single);
		}
	}
}
