using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.1f;
    private Material _material;
    private Vector2 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(0f, _scrollSpeed );
    }

    // Update is called once per frame
    void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
