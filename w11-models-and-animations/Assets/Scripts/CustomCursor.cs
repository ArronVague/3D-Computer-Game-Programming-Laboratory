using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GUIStyle textStyle; // 文本样式，可以在Inspector中调整
    private string textToDisplay = "o"; // 要显示的文本

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // 隐藏系统鼠标光标
        Cursor.visible = false;
    }

    void OnGUI()
    {
        // 设置文本的位置为屏幕中心
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // 绘制文本
        GUI.Label(new Rect(centerX, centerY, 100, 100), textToDisplay, textStyle);
    }
}