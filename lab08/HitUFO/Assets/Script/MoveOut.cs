using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOut : MonoBehaviour
{
    UFO ufo;
    bool onScreen = true;
    Vector3 position;

    public void SetDepend(UFO ufo)
    {
        this.ufo = ufo;
    }

    void Update()
    {
        if (!onScreen)
        {
            return;
        }
        this.position = ufo.ufoObject.transform.position;
        if (this.position.x < -15 || this.position.x > 15 || this.position.y <-8 || this.position.y > 8)
        {
            onScreen = false;
            ufo.Fail();
        }
    }
}