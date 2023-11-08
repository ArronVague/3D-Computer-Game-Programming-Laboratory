using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{

    SceneController CurrentSceneController;
    GUIStyle msgStyle, titleStyle;
    string roundText, bloodText, scoreText;
/*    private bool hideRestart;*/

    void Start(){
        CurrentSceneController = Director.GetInstance().CurrentSceneController;

        msgStyle = new GUIStyle();
        msgStyle.normal.textColor = Color.black;
        msgStyle.alignment = TextAnchor.MiddleCenter;
        msgStyle.fontSize = 30;

        titleStyle = new GUIStyle();
        titleStyle.normal.textColor = Color.black;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.fontSize = 60;
        /*hideRestart = true;*/
    }

    void OnGUI(){

        roundText = $"Round: {CurrentSceneController.round}";
        bloodText = $"Blood: {CurrentSceneController.blood}";
        scoreText = $"Score: {CurrentSceneController.score}";

        if (CurrentSceneController.isStart)
        {
            if (GUI.Button(new Rect(Screen.width * 0.75f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.1f), "End"))
            {
                CurrentSceneController.EndGame();
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width * 0.75f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.1f), "Start"))
            {
                CurrentSceneController.StartNewGame();
            }
        }


        // 标题与其他提示信息
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height*0.2f), "Hit UFO", titleStyle);
        GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), roundText, msgStyle);
        GUI.Label(new Rect(0, Screen.height*0.1f, Screen.width*0.15f, Screen.height*0.1f), bloodText, msgStyle);
        GUI.Label(new Rect(0, Screen.height*0.2f, Screen.width*0.15f, Screen.height*0.1f), scoreText, msgStyle);
        //判断是否结束游戏
        if(CurrentSceneController.isFailed){
            GUI.Label(new Rect(0, Screen.height*0.4f, Screen.width, Screen.height*0.2f), "Game Over.", titleStyle);
        }
    }
}
