using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int num;//ÿ���ж����ض��ķ���
    public play EmitDisk;
    public FirstController sceneController;//����
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
                sceneController.score += num;//�ӷ�
            }
            EmitDisk = (play)other.gameObject.GetComponent<Data>().Action;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;//���ڼ�����  
            EmitDisk.Destroy();//�������
        }

    }
}