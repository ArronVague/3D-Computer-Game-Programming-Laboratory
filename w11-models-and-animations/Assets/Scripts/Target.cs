using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int num;//每个靶都有特定的分数
    public play EmitDisk;
    public FirstController sceneController;//场记
    //private ScoreRecorder recorder;
    public void Start()
    {
        Debug.Log("target");
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
        /*        Debug.Log(other.gameObject);*/
        if (other.gameObject.tag == "Arrow")
        {
            if (!other.gameObject.GetComponent<Data>().hit)
            {
                other.gameObject.GetComponent<Data>().hit = true;
                Debug.Log(num);
            }

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // 将刚体设置为Kinematic，停止物理模拟
            other.gameObject.transform.SetParent(transform); // 设置箭靶物体为箭的父对象，一起移动
        }
    }
}