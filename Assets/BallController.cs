using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 5.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (speed, speed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
