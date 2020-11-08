using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text scoreDisplayText;
	private GameSession _gameSession;

	private void Awake() {
		_gameSession = FindObjectOfType<GameSession>();
	}

	private void Update() {
		if (scoreDisplayText != null) {
			scoreDisplayText.text = _gameSession.GetScore().ToString();
		}
	}
}
