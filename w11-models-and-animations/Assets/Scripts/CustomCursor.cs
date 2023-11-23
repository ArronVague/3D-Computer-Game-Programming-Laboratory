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

    void OnGUI()
    {
        // �����ı���λ��Ϊ��Ļ����
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // �����ı�
        GUI.Label(new Rect(centerX, centerY, 100, 100), textToDisplay, textStyle);
    }
}