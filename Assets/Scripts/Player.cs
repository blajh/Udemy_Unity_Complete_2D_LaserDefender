using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private float _xMinViewPos = 0.07f;
    private float _xMaxViewPos = 0.93f;
    private float _xMinWorldPos;
    private float _xMaxWorldPos;

    private float _yMinViewPos = 0.03f;
    private float _yMaxViewPos = 0.97f;
    private float _yMinWorldPos;
    private float _yMaxWorldPos;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

	private void SetUpMoveBoundaries() {
		Camera _gameCamera = Camera.main;
        _xMinWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(_xMinViewPos, 0, 0)).x;
		_xMaxWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(_xMaxViewPos, 0, 0)).x;
        _yMinWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(0, _yMinViewPos, 0)).y;
        _yMaxWorldPos = _gameCamera.ViewportToWorldPoint(new Vector3(0, _yMaxViewPos, 0)).y;
    }

	// Update is called once per frame
	void Update()
    {
        Move();
    }

    private void Move() {
        var _deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        var _deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        var _newXPos = Mathf.Clamp (transform.position.x + _deltaX, _xMinWorldPos, _xMaxWorldPos);
        var _newYPos = Mathf.Clamp (transform.position.y + _deltaY, _yMinWorldPos, _yMaxWorldPos);
        transform.position = new Vector2(_newXPos, _newYPos);
    }
}
