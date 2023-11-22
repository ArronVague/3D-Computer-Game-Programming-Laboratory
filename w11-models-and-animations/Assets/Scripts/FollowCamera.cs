using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform; // bow's transform
    public Vector3 offset;

    void LateUpdate()
    {
        if (cameraTransform != null)
        {
            // ��ȡ���������ת
            Quaternion cameraRotation = cameraTransform.rotation;

            // Ӧ�������ת��ƫ����
            Vector3 rotatedOffset = cameraRotation * offset;

            // ���ù���λ��Ϊ�����λ�ü���ƫ����
            transform.position = cameraTransform.position + rotatedOffset;

            // ���ù�����תΪ���������ת
            transform.rotation = cameraRotation;
        }
    }
}