using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BallController : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.mass = 0.02f;
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(speed, speed));

        this.OnCollisionEnter2DAsObservable()
            .Where(collision => collision.gameObject.CompareTag("Wall"))
            .Subscribe(_ => GameManager.Instance.GameOver());        
    }
}
