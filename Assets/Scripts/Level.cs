using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	public void LoadStartMenu() {
		SceneManager.LoadScene(0);
	}

	public void LoadGameScene() {
		SceneManager.LoadScene(1);
	}

	public void LoadGameOver() {
		SceneManager.LoadScene(2);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
