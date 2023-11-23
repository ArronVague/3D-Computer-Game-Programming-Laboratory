using Com.Mygame;
using System.Globalization;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ArrowCollision : MonoBehaviour
{
    private Quaternion initialRotation; // 保存箭的初始角度
    private bool hasCollided = false; // 碰撞标志位
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
            // 获取碰撞前的角度
            Quaternion preCollisionRotation = initialRotation;

            // 停止运动
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            arrowRigidbody.isKinematic = true;
            arrowRigidbody.velocity = Vector3.zero;
            arrowRigidbody.angularVelocity = Vector3.zero;

            // 设置角度
            transform.rotation = preCollisionRotation;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
}