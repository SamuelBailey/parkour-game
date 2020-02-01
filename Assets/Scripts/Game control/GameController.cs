using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public static bool levelStarted;
	public static float levelTimer;
	public static int numberOfDeaths;


	public static int numberOfLevels = 1;
	public static float currentScore;
	public static float highScore;

	public static int currentLevel = 0;
	public static int unlockedLevel;



	void Start ()
	{
		numberOfLevels = 3;
	}

	void Update ()
	{
		if (Input.GetAxisRaw ("Cancel") != 0.0f) {
			SceneManager.LoadScene (0);
		}
	}

	public static void EndLevel (int levelNumber)
	{
		SceneManager.LoadScene (levelNumber);
	}

	void LoadLevel (int levelNumber)
	{
		SceneManager.LoadScene (levelNumber);
	}
}
