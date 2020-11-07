using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[Header("Player")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _health = 200;

    private float _xMinViewPos = 0.07f;
    private float _xMaxViewPos = 0.93f;
    private float _xMinWorldPos;
    private float _xMaxWorldPos;

    private float _yMinViewPos = 0.03f;
    private float _yMaxViewPos = 0.97f;
    private float _yMinWorldPos;
    private float _yMaxWorldPos;

    [Header("Projectile")]
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private float _projectileFiringPeriod = 0.1f;

    private Coroutine _firingCoroutine;

    // Start is called before the first frame update
    void Start() {
		SetUpMoveBoundaries();
	}

	// Update is called once per frame
	void Update()
    {
        Move();
        Fire();
    }

    private void Move() {
        var _deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        var _deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        var _newXPos = Mathf.Clamp (transform.position.x + _deltaX, _xMinWorldPos, _xMaxWorldPos);
        var _newYPos = Mathf.Clamp (transform.position.y + _deltaY, _yMinWorldPos, _yMaxWorldPos);
        transform.position = new Vector2(_newXPos, _newYPos);
    }

	private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            _firingCoroutine = StartCoroutine(FireContinuosly());
		}
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(_firingCoroutine);
        }
    }

	IEnumerator FireContinuosly() {
		while (true) {
			GameObject _laser = Instantiate
				(_laserPrefab, transform.position, Quaternion.identity)
				as GameObject;
			_laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
			yield return new WaitForSeconds(_projectileFiringPeriod);
		}
	}

	private void SetUpMoveBoundaries() {
		Camera _gameCamera = Camera.main;
        _xMinWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(_xMinViewPos, 0, 0)).x;
		_xMaxWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(_xMaxViewPos, 0, 0)).x;
        _yMinWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(0, _yMinViewPos, 0)).y;
        _yMaxWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(0, _yMaxViewPos, 0)).y;
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
}
