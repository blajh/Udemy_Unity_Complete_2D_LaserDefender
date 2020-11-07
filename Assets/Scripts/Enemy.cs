using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float _health = 100;
	[SerializeField] private float _shotCounter;
	[SerializeField] private float _minTimeBetweenShots = 0.2f;
	[SerializeField] private float _maxTimeBetweenShots = 3f;
	[SerializeField] private GameObject _laserPrefab;
	[SerializeField] private float _projectileSpeed = 10f;

	private void Start() {
		RandomiseShotDuration(); 
	}

	private void Update() {
		CountDownAndShoot();
	}

	private void CountDownAndShoot() {
		_shotCounter -= Time.deltaTime;
		if (_shotCounter <= 0) {
			Fire();
			RandomiseShotDuration();
		}
	}

	private void Fire() {
		GameObject _laser = Instantiate
			(_laserPrefab, transform.position, Quaternion.identity)
			as GameObject;
		_laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - _projectileSpeed);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		DamageDealer _damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if (_damageDealer != null) {
			ProcessHit(_damageDealer);
		}
	}

	private void ProcessHit(DamageDealer _damageDealer) {
		_health -= _damageDealer.GetDamage();
		_damageDealer.Hit();
		if (_health <= 0) {
			Destroy(gameObject);
		}
	}

	private void RandomiseShotDuration() {
		_shotCounter = UnityEngine.Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
	}
}
