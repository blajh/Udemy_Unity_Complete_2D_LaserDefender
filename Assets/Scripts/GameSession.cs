using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	[SerializeField] private int _currentScore = 0;
	[SerializeField] private int _pointsPerEnemy = 35;

	private void Awake() {
		SetUpSingleton();
	}

	private void SetUpSingleton() {
		int gameStatusCount = FindObjectsOfType(GetType()).Length;
		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}

		else {
			DontDestroyOnLoad(gameObject);
		}
	}

	public int GetScore() {
		return _currentScore;
	}

	public void AddToScore() {
		_currentScore += _pointsPerEnemy;
	}

	public void RestartScore() {
		_currentScore = 0;
	}
}
