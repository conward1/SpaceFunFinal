using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCrew : MonoBehaviour {

	public static bool changeHappened = false;
	SpriteRenderer render;
	Sprite crewMember;

	// Use this for initialization
	void Start () 
	{
		render = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		int whichCrewMember = DialogText.indexOfScene;

		switch (whichCrewMember) 
		{
		case 4:
			crewMember = Resources.Load<Sprite> ("sally");
			break;
		case 6:
			crewMember = Resources.Load<Sprite> ("neil");
			break;
		case 8:
			crewMember = Resources.Load<Sprite> ("mae");
			break;
		}
	}

	void OnMouseDown()
	{
		render.sprite = crewMember;
		changeHappened = true;
	}
}
