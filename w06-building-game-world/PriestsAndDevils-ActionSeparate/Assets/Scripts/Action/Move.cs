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
            /*如果moveMode为single，则desseq数组长度为1，将目标位置destination赋值给desseq[0]；如果moveMode为sequence，则desseq数组长度为3，分别将当前位置(transform.localPosition)和目标位置(destination)在Y轴上升高1个单位后赋值给desseq[0]和desseq[1]，并将目标位置destination赋值给desseq[2]。*/
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
        /*如果n_seq大于等于desseq数组的长度，表示已经完成了所有的移动序列，将一些变量重置为默认值，并将isMoving设置为false，然后返回。*/
        if (n_seq >= desseq.Length)
        {
            n_seq = 0;
            moveMode = -1;
            initialized = false;
            isMoving = false;
            return;
        }
        /*如果当前位置(transform.localPosition)与desseq[n_seq]相等，则表示已经到达当前目标位置，将n_seq加1，表示切换到下一个目标位置。*/
        if (transform.localPosition == desseq[n_seq])
        {
            n_seq++;
            return;
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, desseq[n_seq], speed * Time.deltaTime);
    }
}
