using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToLevel : MonoBehaviour {
	public void LoadOn(int sceneNumber)
	{
		SceneManager.LoadScene (sceneNumber);
	}

	public void LoadOn(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
