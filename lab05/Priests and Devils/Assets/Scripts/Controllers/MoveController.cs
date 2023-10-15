using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController
{
    GameObject moveObject;

    public bool IsMoving(){
        return(this.moveObject != null && this.moveObject.GetComponent<Move>().isMoving == true);
    }


    public void SetMove(GameObject moveObject, Vector3 destination) {
        // 设置一个新的移动
        Move test;
        this.moveObject = moveObject;
        if (!moveObject.TryGetComponent<Move>(out test)) {
            moveObject.AddComponent<Move>();
        }
        this.moveObject.GetComponent<Move>().destination = destination;
    }
}
