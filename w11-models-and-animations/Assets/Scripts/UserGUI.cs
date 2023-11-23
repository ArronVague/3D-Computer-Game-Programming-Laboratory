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
        // ʵ��������
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
        // �����ı�
        GUI.Label(new Rect(0, 0, 400, 400), "score: " + firstController.score, fontstyle);
    }
}