using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenForInput();
    }

    private void ListenForInput() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            UpdatePosition("UpArrow");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            UpdatePosition("LeftArrow");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            UpdatePosition("DownArrow");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            UpdatePosition("RightArrow");
        }
    }

	private void UpdatePosition(string _direction) {
		if (_direction == "UpArrow") {
			transform.Translate(new Vector3(0f, _moveSpeed * Time.deltaTime, 0f));
		}
		else if(_direction == "LeftArrow") {
            transform.Translate(new Vector3(- _moveSpeed * Time.deltaTime, 0f, 0f));
        }
        else if (_direction == "DownArrow") {
            transform.Translate(new Vector3(0f, - _moveSpeed * Time.deltaTime, 0f));
        }
        else if (_direction == "RightArrow") {
            transform.Translate(new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f));
        }
    }
}
