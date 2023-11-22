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
            // 获取摄像机的旋转
            Quaternion cameraRotation = cameraTransform.rotation;

            // 应用相对旋转到偏移量
            Vector3 rotatedOffset = cameraRotation * offset;

            // 设置弓的位置为摄像机位置加上偏移量
            transform.position = cameraTransform.position + rotatedOffset;

            // 设置弓的旋转为摄像机的旋转
            transform.rotation = cameraRotation;
        }
    }
}