using Com.Mygame;
using System.Globalization;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ArrowCollision : MonoBehaviour
{
    private Quaternion initialRotation; // ������ĳ�ʼ�Ƕ�
    private bool hasCollided = false; // ��ײ��־λ
    public FirstController firstController;

    private void Start()
    {
        initialRotation = transform.rotation;
        firstController = (FirstController)SSDirector.getInstance().currentSceneController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && !hasCollided)
        {
            hasCollided = true;
            firstController.score++;
            // ��ȡ��ײǰ�ĽǶ�
            Quaternion preCollisionRotation = initialRotation;

            // ֹͣ�˶�
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            arrowRigidbody.isKinematic = true;
            arrowRigidbody.velocity = Vector3.zero;
            arrowRigidbody.angularVelocity = Vector3.zero;

            // ���ýǶ�
            transform.rotation = preCollisionRotation;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
}