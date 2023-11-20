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
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("jizhong");
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Arrow")
        {
            if (!other.gameObject.GetComponent<Data>().hit)
            {
                other.gameObject.GetComponent<Data>().hit = true;
                Debug.Log(num);
                sceneController.score += num;//加分
            }
            EmitDisk = (play)other.gameObject.GetComponent<Data>().Action;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;//插在箭靶上  
            EmitDisk.Destroy();//动作完成
        }

    }
}