using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f;
    public float minYAngle = -90f;
    public float maxYAngle = 90f;

    private float rotationX = 0f;


    void Update()
    {
        // move control
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // ��ȡ�������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ��ת�����ˮƽ����
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        // ���㴹ֱ�������ת�Ƕ�
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);

        // Ӧ�ô�ֱ�������ת
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0);
    }
}