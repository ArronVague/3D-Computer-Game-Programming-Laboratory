using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Com.Mygame;

public class UserGUI : MonoBehaviour
{

    private IUserAction action;     // 用户动作接口
    private ISceneController queryInt;   // 场景接口
    public new Camera camera;
    public FirstController firstController;

    void Start()
    {
        firstController = (FirstController)SSDirector.getInstance().currentSceneController;
        // 实例化对象
        action = SSDirector.getInstance().currentSceneController as IUserAction;
        queryInt = SSDirector.getInstance().currentSceneController as ISceneController;
    }
    void Update()
    {
    }

    void OnGUI()
    {
        GUIStyle fontstyle1 = new GUIStyle();
        fontstyle1.fontSize = 50;
        fontstyle1.normal.textColor = new Color(255, 255, 255);
        // 绘制文本
        GUI.Label(new Rect(0, 0, 400, 400), "score: " + firstController.score, fontstyle1);
    }
}