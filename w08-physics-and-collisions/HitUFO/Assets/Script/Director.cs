using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object
{
    static Director _instance;
    public SceneController CurrentSceneController {get; set;}
    public static Director GetInstance() {
        if (_instance == null) {
            _instance = new Director();
        }
        return _instance;
    }
}