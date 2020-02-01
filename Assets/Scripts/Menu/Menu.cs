using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {
	public Canvas mainCanvas;
	public Canvas optionsCanvas;
	public Canvas levelSelectCanvas;
	public int level;

	void Awake ()
	{
		optionsCanvas.enabled = false;
		levelSelectCanvas.enabled = false;
		mainCanvas.enabled = true;
	}

	public void OptionsOn ()
	{
		optionsCanvas.enabled = true;
		mainCanvas.enabled = false;
		levelSelectCanvas.enabled = false;
	}

	public void LevelSelectOn ()
	{
		optionsCanvas.enabled = false;
		mainCanvas.enabled = false;
		levelSelectCanvas.enabled = true;

	}

	public void ReturnOn ()
	{
		optionsCanvas.enabled = false;
		mainCanvas.enabled = true;
		levelSelectCanvas.enabled = false;
	}

	public void LoadOn (int levelNumber)
	{
		SceneManager.LoadScene (levelNumber);
		GameController.levelStarted = false;
		GameController.levelTimer = 0.0f;
		GameController.numberOfDeaths = 0;
	}

	public void Exit ()
	{
		Application.Quit ();
	}
}
