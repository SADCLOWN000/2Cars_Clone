using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndObstacles : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb2d;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        speed = 10;
        _rb2d.velocity = new Vector2(0, -speed);
    }
}
