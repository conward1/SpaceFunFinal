using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
	private string numberOfRightAnswers;
	private string questionString;
	private string[] answerChoices = new string[4];
	private string[] correctAnswer = new string[2];

	public Question(string numberOfRightAnswers, string questionString, string[] answerChoices, string[] correctAnswer){
		this.numberOfRightAnswers = numberOfRightAnswers;
		this.questionString = questionString;
		for (int i = 0; i < 4; i++) {
			this.answerChoices [i] = answerChoices [i];
		}
		for (int i = 0; i < System.Convert.ToInt32(numberOfRightAnswers); i++) {
			this.correctAnswer[i] = correctAnswer[i];
		}
	}

	public string getNumberOfRightAnswers(){
		return this.numberOfRightAnswers;
	}

	public string getQuestionString(){
		return this.questionString;
	}

	public string getAnswerChoice(int answerChoice){
		return this.answerChoices[(answerChoice)];
	}

	public string getCorrectAnswer(int correctAnswer){
		return this.correctAnswer[correctAnswer];
	}

	public bool isAnswerCorrect(string answerSelected, string[] correctAnswers){
		if (answerSelected == correctAnswer[0] || answerSelected == correctAnswer[1]) {
			return true;
		} else {
			return false;
		}
	}
}

