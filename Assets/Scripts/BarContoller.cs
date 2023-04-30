using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarContoller : MonoBehaviour
{
    private float oldX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
        else if (Input.GetMouseButton(0))
        {
            var newX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            transform.Translate(new Vector2((newX - oldX) * 20, 0));
            oldX = newX;
        }
    }
}
