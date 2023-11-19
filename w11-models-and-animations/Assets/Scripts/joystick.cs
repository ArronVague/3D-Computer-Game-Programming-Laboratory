using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    public float speedY = 10.0f;
    public float speedX = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float translationY = Input.GetAxis("Vertical") * speedY;
        float translationX = Input.GetAxis("Horizontal") * speedX;
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;
        transform.Translate(0, translationY, 0);
        transform.Translate(translationX, 0, 0);
    }
}