using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
	private void Awake() {
		int gameStatusCount = FindObjectsOfType<Singleton>().Length;
		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}

		else {
			DontDestroyOnLoad(gameObject);
		}
	}
}
