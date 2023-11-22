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
            // ����������ΪKinematic��ֹͣ����ģ��
            other.gameObject.transform.SetParent(transform); // ���ü�������Ϊ���ĸ�����һ���ƶ�
        }
    }
}