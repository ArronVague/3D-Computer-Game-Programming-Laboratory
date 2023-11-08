using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public int round;
    public int score;
    public int blood;
    public bool isStart;
    public bool isFailed;
    public int currentDifficulty;

    GameObject factory;

    public void Awake(){
        Director director = Director.GetInstance();
        director.CurrentSceneController = this;
        director.CurrentSceneController.Initialize();
        factory = new GameObject("UFO factory");
        factory.AddComponent<UFOFactory>();
        factory.GetComponent<UFOFactory>().SetDepend(this);
    }

    //对场景参数进行初始化
    public void Initialize(){
        round = 1;
        score = 0;
        blood = 10;
        currentDifficulty = 0;
        isStart = false;
        isFailed = false;
    }

    //点击飞碟时触发加分
    public void AddScore(){
        score += 1;
    }

    // UFO飞出窗口时触发减分
    public void SubBlood(){
        if(blood > 0){
            blood -= 1;
        }
        if(blood == 0){
            isFailed = true;
            factory.GetComponent<UFOFactory>().InitializeUFO();
            isStart = false;
        }
    }

    //开始一次新游戏
    public void StartNewGame(){
        Initialize();
        isStart = true;
        StartRound();
    } 

    public void EndGame()
    {
        isStart = false;
        isFailed = true;
        factory.GetComponent<UFOFactory>().InitializeUFO();
    }

    //开始一轮抛掷飞碟（10个）
    public void StartRound(){
        factory.GetComponent<UFOFactory>().SetDifficulty(currentDifficulty);
        factory.GetComponent<UFOFactory>().InitializeUFO();
        factory.GetComponent<UFOFactory>().StartRound();
    }

    //当一轮游戏结束，通知开始下一轮游戏
    public void RoundDone(){
        round++;
        currentDifficulty++;
        StartRound();
    }
}
