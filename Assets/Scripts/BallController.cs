using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();        
        rigidbody.angularDrag = 0;
        rigidbody.mass = 0.02f;
        rigidbody.gravityScale = 0;
        rigidbody.AddForce(new Vector2(speed, speed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
