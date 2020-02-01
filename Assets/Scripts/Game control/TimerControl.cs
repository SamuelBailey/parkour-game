using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerControl : MonoBehaviour {

	float startTime;
	bool timerStarted;
	Text displayTime;

	void Awake ()
	{
		timerStarted = false;
		displayTime = GetComponent<Text> ();
	}

	void FixedUpdate ()
	{
		if (GameController.levelStarted == true) {
			if (timerStarted == false) {
				startTime = Time.time;
				timerStarted = true;
			}
			GameController.levelTimer = Time.time - startTime;

		}
		displayTime.text = GameController.levelTimer.ToString("N2");

		if (GameController.levelStarted == false) {
			timerStarted = false;
		}
	}
}
