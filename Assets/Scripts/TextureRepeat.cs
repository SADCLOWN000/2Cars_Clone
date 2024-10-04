using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRepeat : MonoBehaviour
{
    [SerializeField] private float roadSpeed = 1;
    private Vector2 _offset;
    private void Update()
    {
        _offset = new Vector2(0, Time.time * roadSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = _offset;
    }
}
