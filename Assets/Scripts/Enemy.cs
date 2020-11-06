using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float health = 100;

	private void OnTriggerEnter2D(Collider2D other) {
		DamageDealer _damageDealer = other.gameObject.GetComponent<DamageDealer>();
		ProcessHit(_damageDealer);
	}

	private void ProcessHit(DamageDealer _damageDealer) {
		health -= _damageDealer.GetDamage();
		_damageDealer.Hit();
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
