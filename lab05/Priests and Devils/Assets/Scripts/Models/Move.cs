using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool isMoving;
    public float speed = 5;
    public Vector3 destination;
    
    void Update()
    {
        if (transform.localPosition == destination) {
            isMoving = false;
            return;
        }
        isMoving = true;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed * Time.deltaTime);
    }
}
