using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

	[SerializeField] private TMP_Text healthDisplayText;
	private Player _player;

	private void Awake() {
		_player = FindObjectOfType<Player>();
	}

	private void Update() {
		if (healthDisplayText != null) {
			healthDisplayText.text = _player.GetHealth().ToString();
		}
	}
}
