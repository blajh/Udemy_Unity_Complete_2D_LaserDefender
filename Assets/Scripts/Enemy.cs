using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float _health = 100;

	[Header("Shooting")]
	[SerializeField] private float _shotCounter;
	[SerializeField] private float _minTimeBetweenShots = 0.2f;
	[SerializeField] private float _maxTimeBetweenShots = 3f;
	[SerializeField] private GameObject _laserPrefab;
	[SerializeField] private float _projectileSpeed = 10f;

	[Header("Explosion Particles")]
	[SerializeField] private GameObject _explosionParticles;
	[SerializeField] private float _explosionDuration = 1f;

	[Header("SFX")]
	[SerializeField] private AudioClip _enemyLaserSFX;
	[SerializeField, Range(0f, 1f)] private float _enemyLaserSFXVolume = 0.8f;
	[SerializeField] private AudioClip _enemyDeathSFX;
	[SerializeField, Range(0f, 1f)] private float _enemyDeathSFXVolume = 0.8f;
	private Vector3 cameraPos;

	private void Start() {
		RandomiseShotDuration();
		cameraPos = Camera.main.transform.position;
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
		PlayClipAtPoint(_enemyLaserSFX, _enemyLaserSFXVolume);
	}

	private void RandomiseShotDuration() {
		_shotCounter = UnityEngine.Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
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
			Die();
		}
	}

	private void Die() {
		PlayClipAtPoint(_enemyDeathSFX, _enemyDeathSFXVolume);
		SpawnExplosionParicles();
		Destroy(gameObject);
	}

	private void SpawnExplosionParicles() {
		GameObject explosionParticles = Instantiate
			(_explosionParticles, transform.position, Quaternion.identity)
			as GameObject;
		Destroy(explosionParticles, _explosionDuration);
	}

	private void PlayClipAtPoint(AudioClip audioClip, float audioVolume) {
		AudioSource.PlayClipAtPoint(audioClip, cameraPos, audioVolume);
	}
}
