using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Com.Mygame;

public class UserGUI : MonoBehaviour
{
    public new Camera camera;
    public FirstController firstController;
    public GUIStyle fontstyle;

    void Start()
    {
        firstController = (FirstController)SSDirector.getInstance().currentSceneController;
        // 实例化对象
        fontstyle = new GUIStyle
        {
            fontSize = 50
        };
        fontstyle.normal.textColor = Color.white;
    }
    void Update()
    {
    }

    void OnGUI()
    {
        // 绘制文本
        GUI.Label(new Rect(0, 0, 400, 400), "score: " + firstController.score, fontstyle);
    }
}