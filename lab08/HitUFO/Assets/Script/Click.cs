using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    UFO ufo;

    public void SetDepend(UFO ufo)
    {
        this.ufo = ufo;
    }

    void OnMouseDown()
    {
        this.ufo.Click();    
    }
}