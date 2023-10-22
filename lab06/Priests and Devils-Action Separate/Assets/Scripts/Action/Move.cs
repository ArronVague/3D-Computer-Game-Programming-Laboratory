using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static int single = 0;
    public static int sequence = 1;

    public bool isMoving;
    bool initialized;
    public int moveMode;
    public bool doneMoving;

    public float speed = 5;

    int n_seq;
    public Vector3[] desseq;
    public Vector3 destination;
    public CCMoveAction moveAction;

    public Move()
    {
        n_seq = 0;
        isMoving = false;
        initialized = false;
        moveMode = -1;
    }

    void Update()
    {
        if (moveMode == -1)
        {
            return;
        } 
        if (!initialized)
        {
            if (moveMode == single)
            {
                desseq = new Vector3[1];
                desseq[0] = destination;
            }
            else if (moveMode == sequence)
            {
                desseq = new Vector3[3];
                desseq[0] = transform.localPosition + new Vector3(0, 1, 0);
                desseq[1] = destination + new Vector3(0, 1, 0);
                desseq[2] = destination;
            }
            else
            {
                Debug.Log("ERROR");
            }
            initialized = true;
        }
        isMoving = true;
        if (n_seq >= desseq.Length)
        {
            n_seq = 0;
            moveMode = -1;
            initialized = false;
            isMoving = false;
            return;
        }
        if (transform.localPosition == desseq[n_seq])
        {
            n_seq++;
            return;
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, desseq[n_seq], speed * Time.deltaTime);
    }
}
