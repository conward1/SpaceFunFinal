using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class CardDrag : MonoBehaviour
{
	private Vector3 touchDown;
	private Vector3 touchUp;
	private Vector3 origin;
	private Rigidbody2D rigidbody;
	private int numOfCards = 4;
	private static int cardsReset = 0;
	public static int cardsRemoved = 0;
	public static int answerNumber = 0;
	public static Text answerSelected;
	public static int cardSelected;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		origin = transform.position;
	}

	//updates every frame, if resetQuestion is true it moves cards back to proper place and sets resetQuestion to false
	void Update()
	{
		if (QuestionGetter.resetQuestion && (cardsReset < numOfCards)) {
			cardsRemoved = 0;
			this.transform.position = origin;
			//Debug.Log ("Cards Removed: " + cardsRemoved);
			cardsReset += 1;
			//Debug.Log ("Cards Reset: " + cardsReset);
		} 
		else if (QuestionGetter.resetQuestion && cardsReset >= numOfCards) 
		{
			QuestionGetter.resetQuestion = false;
			cardsReset = 0;
			//Debug.Log ("Cards Reset: " + cardsReset);
			//Debug.Log ("Reset Question?: " + QuestionGetter.resetQuestion);
		}
	}

	void OnMouseDown()
	{
		touchDown = Input.mousePosition;
	}

	//determines direction answer card will move
	void OnMouseDrag ()
	{
		touchUp = Input.mousePosition;

		if (touchUp.x > touchDown.x) 
		{
			rigidbody.AddForce(new Vector2(20f, 0f));
		}
		else if (touchUp.x < touchDown.x) 
		{
			rigidbody.AddForce(new Vector2(-20f, 0f));
		}
	}

	//keeps track of cards removed, need to add functionality to see if answers were correct
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("background"))
		{
			cardsRemoved += 1;
			//Debug.Log ("Cards Removed: " + cardsRemoved);
		}
		if (other.gameObject.CompareTag ("answerCard1")) {
			answerSelected = GameObject.Find ("Answer1").GetComponent<Text>();
			cardSelected = 1;
			print ("in card1");
			cardsRemoved += 1;
			if (answerSelected.text == QuestionGetter.correctAnswer1 || answerSelected.text == QuestionGetter.correctAnswer2) {
				QuestionGetter.correctAnswersReached++;
				if (QuestionGetter.correctAnswersReached == QuestionGetter.numOfCorectAnswers) {
					QuestionGetter.wonRounds++;
					QuestionGetter.correctAnswersReached = 0;
					print ("Won Rounds: " + QuestionGetter.wonRounds);
					print ("Answer Correct");
					resetQuestion();
				}
			} else {
				QuestionGetter.lossRounds++;
				QuestionGetter.correctAnswersReached = 0;
				print ("Answer Wrong");
				resetQuestion();
			}
		}
		if (other.gameObject.CompareTag ("answerCard2")) {
			answerSelected = GameObject.Find ("Answer2").GetComponent<Text>();
			cardSelected = 2;
			print ("in card2");
			cardsRemoved += 1;
			if (answerSelected.text == QuestionGetter.correctAnswer1 || answerSelected.text == QuestionGetter.correctAnswer2) {
				QuestionGetter.correctAnswersReached++;
				if (QuestionGetter.correctAnswersReached == QuestionGetter.numOfCorectAnswers) {
					QuestionGetter.wonRounds++;
					QuestionGetter.correctAnswersReached = 0;
					print ("Won Rounds: " + QuestionGetter.wonRounds);
					print ("Answer Correct");
					resetQuestion();
				}
			} else {
				QuestionGetter.lossRounds++;
				QuestionGetter.correctAnswersReached = 0;
				print ("Answer Wrong");
				resetQuestion();
			}
		}
		if (other.gameObject.CompareTag ("answerCard3")) {
			answerSelected = GameObject.Find ("Answer3").GetComponent<Text>();
			cardSelected = 3;
			print ("in card3");
			cardsRemoved += 1;
			if (answerSelected.text == QuestionGetter.correctAnswer1 || answerSelected.text == QuestionGetter.correctAnswer2) {
				QuestionGetter.correctAnswersReached++;
				if (QuestionGetter.correctAnswersReached == QuestionGetter.numOfCorectAnswers) {
					QuestionGetter.wonRounds++;
					QuestionGetter.correctAnswersReached = 0;
					print ("Won Rounds: " + QuestionGetter.wonRounds);
					print ("Answer Correct");
					resetQuestion();
				}
			} else {
				QuestionGetter.lossRounds++;
				print ("Answer Wrong");
				QuestionGetter.correctAnswersReached = 0;
				resetQuestion();
			}
		}
		if (other.gameObject.CompareTag ("answerCard4")) {
			answerSelected = GameObject.Find ("Answer4").GetComponent<Text>();
			cardSelected = 4;
			print ("in card4");
			print (cardSelected);
			print (answerSelected.text);
			cardsRemoved += 1;
			if (answerSelected.text == QuestionGetter.correctAnswer1 || answerSelected.text == QuestionGetter.correctAnswer2) {
				QuestionGetter.correctAnswersReached++;
				if (QuestionGetter.correctAnswersReached == QuestionGetter.numOfCorectAnswers) {
					QuestionGetter.wonRounds++;
					print ("Answer Correct");
					QuestionGetter.correctAnswersReached = 0;
					print ("Won Rounds: " + QuestionGetter.wonRounds);
					resetQuestion();
				}
			} else {
				QuestionGetter.lossRounds++;
				print ("Answer Wrong");
				QuestionGetter.correctAnswersReached = 0;
				resetQuestion();
			}
		}
	}

	public void resetQuestion(){
		QuestionGetter.resetQuestion = true;
		QuestionGetter.question.text = QuestionGetter.questionCreator ();
		QuestionGetter.answerChoices = QuestionGetter.answerCreator ();
		QuestionGetter.a1.text = QuestionGetter.answerChoices [0];
		QuestionGetter.a2.text = QuestionGetter.answerChoices [1];
		QuestionGetter.a3.text = QuestionGetter.answerChoices [2];
		QuestionGetter.a4.text = QuestionGetter.answerChoices [3];
		QuestionGetter.correctAnswer1 = QuestionGetter.answerChoices [4];
		QuestionGetter.correctAnswer2 = QuestionGetter.answerChoices [5];		
		QuestionGetter.numOfCorectAnswers = System.Convert.ToInt32(QuestionGetter.answerChoices [6]);
	}

}