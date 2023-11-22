using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private Quaternion initialRotation; // ������ĳ�ʼ�Ƕ�
    private bool hasCollided = false; // ��ײ��־λ

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && !hasCollided)
        {
            hasCollided = true;

            // ��ȡ��ײǰ�ĽǶ�
            Quaternion preCollisionRotation = initialRotation;

            // ֹͣ�˶�
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            arrowRigidbody.isKinematic = true;
            arrowRigidbody.velocity = Vector3.zero;
            arrowRigidbody.angularVelocity = Vector3.zero;

            // ���ýǶ�
            transform.rotation = preCollisionRotation;
        }
    }
}