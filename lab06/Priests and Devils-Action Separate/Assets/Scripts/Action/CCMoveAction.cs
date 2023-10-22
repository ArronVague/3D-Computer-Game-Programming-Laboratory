using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveAction
{
    GameObject moveObject;

    public bool IsMoving()
    {
        return (this.moveObject != null && this.moveObject.GetComponent<Move>().isMoving == true);
    }

    public void MoveTo(GameObject moveObject, Vector3 destination)
    {
        Move test;
        this.moveObject = moveObject;
        if (!moveObject.TryGetComponent<Move>(out test))
        {
            moveObject.AddComponent<Move>();
        }
        this.moveObject.GetComponent<Move>().moveAction = this;
        this.moveObject.GetComponent<Move>().destination = destination;
        this.moveObject.GetComponent<Move>().moveMode = Move.single;
    }

    public void MoveSequence(GameObject moveObject, Vector3 destination)
    {
        Move test;
        this.moveObject = moveObject;
        if (!moveObject.TryGetComponent<Move>(out test))
        {
            moveObject.AddComponent<Move>();
        }
        this.moveObject.GetComponent<Move>().moveAction = this;
        this.moveObject.GetComponent<Move>().destination = destination;
        this.moveObject.GetComponent<Move>().moveMode = Move.sequence;
    }
}