using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private Quaternion initialRotation; // 保存箭的初始角度
    private bool hasCollided = false; // 碰撞标志位

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && !hasCollided)
        {
            hasCollided = true;

            // 获取碰撞前的角度
            Quaternion preCollisionRotation = initialRotation;

            // 停止运动
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            arrowRigidbody.isKinematic = true;
            arrowRigidbody.velocity = Vector3.zero;
            arrowRigidbody.angularVelocity = Vector3.zero;

            // 设置角度
            transform.rotation = preCollisionRotation;
        }
    }
}