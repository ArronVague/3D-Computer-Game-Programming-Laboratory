using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GUIStyle textStyle; // �ı���ʽ��������Inspector�е���
    private string textToDisplay = "o"; // Ҫ��ʾ���ı�

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // ����ϵͳ�����
        Cursor.visible = false;
    }

    void Update()
    {
        // ������������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ��Ļ���ĵ�����
            Vector3 centerScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // �������
/*            Debug.Log("Clicked at screen center: " + centerScreen);*/
        }
    }

    void OnGUI()
    {
        // �����ı���λ��Ϊ��Ļ����
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // �����ı�
        GUI.Label(new Rect(centerX, centerY, 100, 100), textToDisplay, textStyle);
    }
}