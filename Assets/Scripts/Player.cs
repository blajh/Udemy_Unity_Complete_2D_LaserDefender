using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        var _deltaX = Input.GetAxis("Horizontal");
        var _posX = transform.position.x + _deltaX * Time.deltaTime * _moveSpeed;
        var _deltaY = Input.GetAxis("Vertical");
        var _posY = transform.position.y + _deltaY * Time.deltaTime * _moveSpeed;
        transform.position = new Vector2(_posX, _posY);
    }
}
