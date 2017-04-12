using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class QuestionGetter : MonoBehaviour {

	public static int requiredCorrect = 1; //number of correct answers in a round
	public static int wonRounds = 0; //keeps track of how many rounds a user has answered correctly
	public static int lossRounds = 0; //keeps track of how many rounds a user has answered inccorectly
	public static int requiredToWin = 4; //number of rounds needed to win to advance to next stage/scene
	public static bool resetQuestion = false;
	public static int questionNumber = 0; //keep track of what question you are on in array
	public static int answerNumber = 0; //keep track of what question you are on for answers
	public static int correctAnswersReached = 0;

	public static int mySceneIndex = 3; //Holds index of next scene to load, starts at 3 because index 3 is first
								//scene loaded this way

	private Rigidbody2D rigidbody;


	public static Text a1, a2, a3, a4, question;
	public static string correctAnswer1 = "";
	public static string correctAnswer2 = "";
	public static int numOfCorectAnswers;

	public static Question[] QuestionArray = new Question[30];//{Question(numberOfRightAnswers, questionString, answerChoices, correctAnswer)};
	public static string[] answerChoices = new string[7]{"","","","","","", ""};
	//QuestionArray[0] = QuestionArray(numberOfRightAnswers, questionString, answerChoices, correctAnswer);
	public void createQuestionArray(){
		QuestionArray[0] = new Question("1", "Complete the expression: \n 402 * _6 = 34572", new string[]{"0", "1", "7", "8"}, new string[]{"8", ""});
		QuestionArray[1] = new Question("1", "Allen ran 5.4 miles on Monday \n and 3.28 miles on Tuesday. How\n many miles did Allen run altogether?", new string[]{"8.12", "9.42", "8.86", "8.68"}, new string[]{"8.68", ""});
		QuestionArray[2] = new Question("1", "What is the value of the expression \n 6 × (4 + 3)?", new string[]{"42", "27", "48", "36"}, new string[]{"42", ""});
		QuestionArray[3] = new Question("1", "Select a the number that you \ncan multiply by 54,216 to get a\nvalue less than 54,216.", new string[]{"7/12", "4/4", "8/5", "12/9"}, new string[]{"7/12", ""});
		QuestionArray[4] = new Question("1", "Which expression could be used to \nfind the  quotient of 1,575 ÷ 21?", new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", "(1,500 ÷ 20) + (75 ÷ 1)", "(1,575 ÷ 21) + (575 ÷ 21) + (75 ÷ 21) + (5 ÷ 21)", "(1,575 ÷ 20) + (1,575 ÷ 1)"}, new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", ""});
		QuestionArray[5] = new Question("1", "What is the missing value \nin the equation? \n2 and (3/12)+(3/_)=2 and (5/8)", new string[]{"8", "6", "7", "4"}, new string[]{"8", ""});
		QuestionArray[6] = new Question("1", "Michael is measuring fabric. He \nneeds 47 feet of fabric. He has \n12 yards of fabric. How many more \nyards of fabric does he need?", new string[]{"10", "3", "10/3", "3/10"}, new string[]{"10/3", ""});
		QuestionArray[7] = new Question("1", "Jasmine has 3/4 cup of flour. After she \nadds more flour, Jasmine says she now \nhas 5/8 cup of flour. Which of these \nexplains why Jasmine is incorrect?", new string[]{"5 is not a multiple of 3", "3 is less than 5", "5/8 is less than 3/4", "5/8 is not a multiple of 3/4"}, new string[]{"5/8 is less than 3/4", ""});
		QuestionArray[8] = new Question("1", "Which statements about the values \n 0.034 and 3.40 are true?", new string[]{"0.034 is (1/10) of 3.40", "0.034 is (1/100) of 3.40", "3.40 is 10 times more than 0.034", "none of the above"}, new string[]{"0.034 is (1/100) of 3.40", ""});
		QuestionArray[9] = new Question("1", "What is the area, in square units, \nof the rectangle with length (3/7) \nunits and height (2/9) units", new string[]{"5/16", "6/63", "6/16", "5/63"}, new string[]{"6/63", ""});
		QuestionArray[10] = new Question("1", "Select all the statements that \n correctly compare the two numbers", new string[]{"1.309 > 1.315", "7.25 > 7.255", "2.001 < 2.10", "none of the above"}, new string[]{"2.001 < 2.10", ""});
		QuestionArray[11] = new Question("1", "How many times greater is \nthe value of 5 in 2,573 than the value of\n5 in 6,459?", new string[]{"10", "50", "100", "500"}, new string[]{"10", ""});
		QuestionArray[12] = new Question("1", "A rectangle has a length of 11 \nfeet and a perimeter of 38 feet.\nWhat is the width, in feet, \nof the rectangle?", new string[]{"16", "8", "11", "27"}, new string[]{"8", ""});
		QuestionArray[13] = new Question("1", "Which set of numbers are prime?", new string[]{"7 and 16", "7 and 9", "7 and 13", "9 and 16"}, new string[]{"7 and 13", ""});
		QuestionArray[14] = new Question("1", "Which expression could be used to \nfind the  quotient of 1,575 ÷ 21?", new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", "(1,500 ÷ 20) + (75 ÷ 1)", "(1,575 ÷ 21) + (575 ÷ 21) + (75 ÷ 21) + (5 ÷ 21)", "(1,575 ÷ 20) + (1,575 ÷ 1)"}, new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", ""});
		QuestionArray[15] = new Question("1", "What is the missing value of \n1and (3/10) in decimal form", new string[]{"1.3", "13.10", "1.31", "13"}, new string[]{"1.3", ""});
		QuestionArray[16] = new Question("1", "What does the number 6 \nrepresent in the expression \n 54/12 = 4 r 6", new string[]{"tenths value", "remainder", "correct answer", "none of \nthe above"}, new string[]{"remainder", ""});
		QuestionArray[17] = new Question("1", "Which statement represents \n45 = 5 × 9?", new string[]{"Rosie collected 5 toy \ncars each year for 9 years.", "Rosie collected 5 toy cars \none year and 9 toy \ncars the next year", "Rosie had a collection of 45 \ntoy cars and gave 9 \nof them away.", "none of the above"}, new string[]{"Rosie collected 5 toy \ncars each year for 9 years.", ""});
		QuestionArray[18] = new Question("1", "Which statements correctly \ncompare two numbers?", new string[]{"2,059 > 2,095", "2,095 < 2,059", "2,059 < 2,095", "2,059 = 2,095"}, new string[]{"2,059 < 2,095", ""});
		QuestionArray[19] = new Question("1", "Johnny has 17 marbles. Mitchell \nhas 3 times as many marbles as \nJohnny. How many marbles \ndoes Mitchell have?", new string[]{"20", "51", "14", "31"}, new string[]{"51", ""});
		QuestionArray[20] = new Question("1", "How many degrees are \na right angle?", new string[]{"45", "180", "90", "80"}, new string[]{"90", ""});
		QuestionArray[21] = new Question("1", "How tall in inches is \n a 5 foot tall table?", new string[]{"60", "50", "5", "72"}, new string[]{"60", ""});
		QuestionArray[22] = new Question("1", "Which set of numbers are Composite", new string[]{"7 and 14", "a2 and 13", "12 and 17", "12 and 16"}, new string[]{"12 and 16", ""});
		QuestionArray[23] = new Question("1", "Select the expression that \nhas the value of 32.", new string[]{"100/3", "224/7", "204/9", "32/2"}, new string[]{"224/7", ""});
		QuestionArray[24] = new Question("1", "Which expression could be used to \nfind the  quotient of 1,575 ÷ 21?", new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", "(1,500 ÷ 20) + (75 ÷ 1)", "(1,575 ÷ 21) + (575 ÷ 21) + (75 ÷ 21) + (5 ÷ 21)", "(1,575 ÷ 20) + (1,575 ÷ 1)"}, new string[]{"(1,000 ÷ 21) + (500 ÷ 21) + (70 ÷ 21) + (5 ÷ 21)", ""});
		QuestionArray[25] = new Question("1", "What is the product of \n2,830 and 3?", new string[]{"2833", "8490", "943", "8493"}, new string[]{"8490", ""});
		QuestionArray[26] = new Question("1", "Complete the comparison \n (6/2)_(7/3)", new string[]{"<", ">", "=", ">="}, new string[]{"6/2", ""});
		QuestionArray[27] = new Question("1", "Select the shape that always contain perpendicular sides", new string[]{"obtuse triangle", "rhombus", "acute triangle", "right triangle"}, new string[]{"right triangle", ""});
		QuestionArray[28] = new Question("1", "A triangle has two angle of \n52 degrees and 18 degrees. \nWhat is the degrees of \nthe third angle?", new string[]{"100", "110", "70", "20"}, new string[]{"110", ""});
		QuestionArray[29] = new Question("1", "What is the remainder \nof 11563/52?", new string[]{"17", "0", "19", "601276"}, new string[]{"19", ""});

	}
		

	// Use this for initialization
	void Awake () 
	{
		createQuestionArray ();
		rigidbody = GetComponent<Rigidbody2D>();
		question = GameObject.Find ("Question").GetComponent<Text>();
		a1 = GameObject.Find ("Answer1").GetComponent<Text>();
		a2 = GameObject.Find ("Answer2").GetComponent<Text>();
		a3 = GameObject.Find ("Answer3").GetComponent<Text>();
		a4 = GameObject.Find ("Answer4").GetComponent<Text>();

		question.text = questionCreator ();
		answerChoices = answerCreator ();
		a1.text = answerChoices [0];
		a2.text = answerChoices [1];
		a3.text = answerChoices [2];
		a4.text = answerChoices [3];
		correctAnswer1 = answerChoices[4];
		correctAnswer2 = answerChoices[5];
		numOfCorectAnswers = System.Convert.ToInt32(answerChoices [6]);
	}
	

	void Update () 
	{
		//Debug.Log ("Reset Questions?: " + resetQuestion);
		if (CardDrag.cardsRemoved == requiredCorrect && !resetQuestion) 
		{
			rigidbody.AddForce(new Vector2(0f, 20f));
		}
		if (wonRounds == requiredToWin) 
		{
			//load the next scene
			Debug.Log (mySceneIndex);
			SceneManager.LoadScene (mySceneIndex, LoadSceneMode.Single);
			wonRounds = 0;
			requiredToWin++;
			mySceneIndex++;
		}
	}

	//updates board
	/*void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("background"))
		{
			wonRounds++;
			resetQuestion = true;
			//add functionality for if player loses round
			//Debug.Log ("Reset Question?: " + resetQuestion);
			//change question & answer text
			question.text = questionCreator();

		}
	}*/

	//creates new questions
	public static string questionCreator()
	{
		if (questionNumber == 30) 
		{
			questionNumber = 0;
		}
		string toReturn = "";

		//creates random index for creating math question.
		//randomMathQuestion = Random.Range (0, mathQuestionMatrix.Length - 1);
		//randomNumber = Random.Range (0, questionNumMatrix.Length - 1);

		toReturn = QuestionArray[questionNumber].getQuestionString();
		questionNumber++;
		return toReturn;
	}

	public static string[] answerCreator()
	{
		if (answerNumber == 30) 
		{
			answerNumber = 0;
		}
		string[] toReturn = new string[7]{"", "", "", "", "", "", ""};
		//answer choices
		toReturn [0] = QuestionArray[answerNumber].getAnswerChoice (0);
		toReturn [1] = QuestionArray[answerNumber].getAnswerChoice (1);
		toReturn [2] = QuestionArray[answerNumber].getAnswerChoice (2);
		toReturn [3] = QuestionArray[answerNumber].getAnswerChoice (3);
		//correct answers
		toReturn[4] = QuestionArray[answerNumber].getCorrectAnswer(0);
		toReturn[5] = QuestionArray[answerNumber].getCorrectAnswer(1);
		toReturn[6] = QuestionArray[answerNumber].getNumberOfRightAnswers();
		answerNumber++;
		return toReturn;
	}
}
