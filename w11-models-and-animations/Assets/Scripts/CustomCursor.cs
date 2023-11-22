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

    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取屏幕中心的坐标
            Vector3 centerScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // 输出坐标
/*            Debug.Log("Clicked at screen center: " + centerScreen);*/
        }
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