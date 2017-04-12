using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogText : MonoBehaviour {

	public static int indexOfScene;
	//arrays of dialog
	private string[] carlDialog0 = new string[]{"Carl: Hello! My name is Astronaut Carl and I need your help!", 
		"Carl: My crew and I seem to have gotten separated while exploring the solar system.", "Carl: Will you help me find them?", 
		"Carl: We can use my spaceship, but it's powered by knowledge.", 
		"Carl: I'll need your help to get it moving!", "Carl: The ship is going to ask you some questions.",
		"Carl: Answer them correctly and the ship will start moving anywhere we want to take it!", "Carl: Let's practice by flying from Earth to the Moon!"};
	private string[] carlDialog1 = new string[]{"Carl: You did it! You got the ship moving. Good Job!", 
		"Carl: We made it to the Moon, but we still have a long way to go if we are going to find the rest of my crew.", "Carl: Let's try to go somewhere even farther...", 
		"Carl: Set a course for Mars!"};
	private string[] carlDialog2 = new string[]{"Carl: Phew! We finally made it.", "Carl: This is the Red Planet Mars. It is the closest planet to Earth.",
		"Carl: Huh?! ...", "Carl: What's that over there?", "Carl: Tap on their helemet to see who it is! It's probably one of my crew members!",
		"Carl: It's Sally!", "Sally: Hey Carl! I thought you'd never find me.", "Sally: Who is this you've brought with you?",
		"Carl: This is my new intelligent friend! They helped me find you. Where's the rest of the crew?", 
		"Sally: I thought they were with you!", "Carl: They must have headed for the outer Solar System. We should head for Jupiter!",
		"Carl: Come on let's go!"};
	private string[] carlDialog3 = new string[]{"Sally: We have arrived at Jupiter, the largest planet in our Solar System.",
		"Carl: Scan the area for any crew members!", "Sally: The ships sensors aren't detecting anything.", "Carl: Where are they?",
		"Sally: Maybe they went to see the rings of Saturn? I hear they're beautiful this time of the solar cycle.", 
		"Carl: Neil was telling me he's never been, I bet they headed that way.", "Sally: Then let's go! Set course for Saturn!"};
	private string[] carlDialog4 = new string[]{"Carl: NEIL ARE YOU OUT THERE?!", "Sally: NEIL WHERE ARE YOU?!",
		"Neil: I'm over here! Just a little dizzy.","Neil: Why hello there friend. Carl who is this?",
		"Carl: I met them after we all got separated. They've been a tremendous help finding everyone.", "Sally: Glad we found you Neil, where are Mae and Rover?",
		"Neil: Rover ran off deeper into the Solar System while Mae and I were admiring Saturn's rings.", "Neil: Mae took off after him and I stayed behind to wait for you guys.",
		"Carl: Rover ran away? That dog is always getting into trouble.", "Sally: Let's go find them! Next stop Uranus!"};
	private string[] carlDialog5 = new string[]{"Neil: Now approaching Uranus, the sideways planet.", "Carl: Why is it called that Neil?",
		"Sally: I can answer that! Uranus's north and south poles are on its sides.", "Sally: This is different from most planets whose north and south poles are on their tops and bottoms.",
		"Sally: This makes Uranus spin on its side hence it being nicknamed the sideways planet.", "Carl: Interesting.",
		"Neil: Any sign of Mae or Rover?", "Carl: We're not picking anything up on our radar.", "Sally: Knowing Rover he proably ran all the way to the to Kuiper Belt.",
		"Carl: Better check the rest of planets in the system. Neptune here we come!"};
	private string[] carlDialog6 = new string[]{"Sally: The ship's scanners are detecting something near Neptune.", 
		"Neil: Good we've found them!", "Carl: It looks like it's just Mae.", "Mae: Hey guys! Rover kept chasing after something after I found him here.",
		"Carl: That silly dog is always running off and getting into trouble.", "Mae: I don't know what he was chasing, but he was determined to follow it all the way to Pluto.",
		"Sally: Well then let's head for Pluto!", "Mae: Alright let's chart a course, but first introduce me to the new member of the crew.",
		"Neil: This is Carl's friend, he found them back on Earth.", "Neil: So far they've helped him track down Sally, you and I",
		"Mae: Well thank you! Hopefully you can help us find our misfit of a crew mascot Rover.", "Mae: Let's get going. We're off to the edge of the Solar System!"};
	private string[] carlDialog7 = new string[]{"Carl: ROVER!", "Neil: COME HERE ROVER!", "Mae: ROVER!", "Sally: ROVER! If you stop running I'll give you a space treat!",
		"Mae: Sally, what's a spa... Oh my! Look at that over there!", "Neil: A.. Al.. Aliens?", "Carl: ALIENS! COOL!", 
		"Sally: Hel.. Hello, by chance have you extra terestrial seen our dog Rover?", "Pink Alien: You mean that thing that's been chasing us since the planet with the rings?",
		"Mae: Yup! That's him.", "Green Alien: We warped him to the star at the center of this system.", "Neil: Poor Rover, look at the mess he's gotten himself into now.",
		"Neil: We'll have to go all the way back to the sun to get him now", "Carl: You mentioned you warped him?", "Pink Alien: Yes warping entails speeding something up towards the speed of light.",
		"Green Alien: You use it to travel long distances.", "Sally: Could you warp us to the sun too so we can go get our dog?", 
		"Pink Alien: Sure! Hold on you're about to go really fast!", "Carl: It was cool meeting you!", "Green Alien: Likewise. Warping you in 3... 2... 1.."};
	private string[] carlDialog8 = new string[]{"Mae: Rover! There you are.", "Rover: Woof!", "Carl: We did it! Everyone let's thank our new found friend for all their help.",
		"Everyone: *clapping & cheering*", "Sally: Alright everyone, let's go home.", "Mae: Next stop EARTH!"};
	private string[] carlDialog9 = new string[]{"Carl: Ahh the pale blue dot, it's good to be home.", "Neil: Thanks again for all your help.", "Sally: Hopefully you learned some things along the way!",
		"Mae: Come back and adventure with us any time!", "Everyone: Goodbye!"};
	private string[] carlFail = new string[]{"Carl: Oh no, we didn't answer enough questions correctly and the ship stopped.",
		"We'll have to go back to the last planet and try again."};


	//temp string array for different scenes dialog
	private string[] temp = new string[]{};

	//index for a particular phrase in a scene
	private int indexOfDialog = 0;

	//does the next scene need to be loaded?
	private bool loadNextScene = false;
	private bool loadFinalScene = false;
	//private bool firstScene = true;

	//variable for text to be output to screen
	private Text displayedText;

	// Use this for initialization
	void Awake ()
	{
		//keeps track of what scene it is so proper dialog can be loaded
		if (PlayerPrefs.GetInt ("level") != 0) {
			indexOfScene = PlayerPrefs.GetInt ("level");
			//loadNextScene = true;
		} 
		else
		{
			indexOfScene = 2;
		}

		//finds text object in scene
		displayedText = GameObject.Find ("CarlText").GetComponent<Text>();

		//assigns correct dialog for scene
		switch (indexOfScene) 
		{
		case 2:
			temp = carlDialog0;
			break;
		case 3:
			temp = carlDialog1;
			break;
		case 4:
			temp = carlDialog2;
			break;
		case 5:
			temp = carlDialog3;
			break;
		case 6:
			temp = carlDialog4;
			break;
		case 7:
			temp = carlDialog5;
			break;
		case 8:
			temp = carlDialog6;
			break;
		case 9:
			temp = carlDialog7;
			break;
		case 10:
			temp = carlDialog8;
			break;
		case 11:
			temp = carlDialog9;
			break;
		case 13:
			temp = carlFail;
			break;
		}

		//begins printing text to screen
		StartCoroutine(AnimateText());
	}

	void Update()
	{
		/*if (loadNextScene && firstScene) {
			indexOfScene++;
			firstScene = false;
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		} 
		else if (loadNextScene && !firstScene) 
		{
			SceneManager.UnloadSceneAsync("questions");
			indexOfScene++;
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		}*/
		if (loadNextScene) {
			//StopAllCoroutines ();
			Debug.Log ("Loading next scene");
			indexOfScene++;
			PlayerPrefs.SetInt ("level", indexOfScene);
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		} 
		else if (loadFinalScene) 
		{
			indexOfScene++;
			SceneManager.LoadScene ("finalScene", LoadSceneMode.Single);
		}
	}

	void OnMouseDown()
	{
		//stops text printing
		StopAllCoroutines ();
		//goes to next dialog
		indexOfDialog++;
		//checks for out of bounds
		if (indexOfDialog == temp.Length && indexOfScene < 11) {
			//Debug.Log ("inside indexOfDialog == temp.Length");
			loadNextScene = true;
		} 
		else if (indexOfDialog == temp.Length && indexOfScene == 11) 
		{
			loadNextScene = false;
			loadFinalScene = true;
		}
		else 
		{
			//restarts printing text
			//Debug.Log ("inside else");
			StartCoroutine(AnimateText());
		}
	}

	IEnumerator AnimateText()
	{
		//Debug.Log ("indexOfDialog: " + indexOfDialog);
		//Debug.Log ("temp[]: " + temp [indexOfDialog]);

		//make text be typed across screen, rather than printed all at once
		if(indexOfDialog < temp.Length)
		{
			for (int i = 0; i < (temp [indexOfDialog].Length + 1); i++) 
			{
				displayedText.text = temp [indexOfDialog].Substring (0, i);
				yield return new WaitForSeconds (0.03f);
			}
		}
		else
		{
			StopCoroutine(AnimateText());
		}
	}
}
