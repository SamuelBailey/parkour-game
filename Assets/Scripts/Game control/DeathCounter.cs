using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathCounter : MonoBehaviour {

	Text displayDeaths;
	bool deathCountStarted;

	void Awake ()
	{
		displayDeaths = GetComponent<Text> ();
	}

	void FixedUpdate ()
	{
		if (GameController.levelStarted == true) {
			if (deathCountStarted == false) {
				GameController.numberOfDeaths = 0;
				deathCountStarted = true;
			}

		}
		displayDeaths.text = GameController.numberOfDeaths.ToString("D");
	}
}
