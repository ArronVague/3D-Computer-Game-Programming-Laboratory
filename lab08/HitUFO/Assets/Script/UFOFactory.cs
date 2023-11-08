using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UFOFactory : MonoBehaviour
{
    public int difficulty;
    public static int trial = 10;
    Coroutine mCoroutine = null; // 协程
    UFO[] UFOs = new UFO[trial];
    public SceneController myController;
    public static Color[] colors = new Color[5] { Color.red, Color.black, Color.blue, Color.green, Color.yellow };
    public static float[] scales = new float[5] { 0.6f, 0.8f, 1.0f, 1.2f, 1.4f };
    public static float[] y_position = new float[5] { 1f, 2f, 3f, 4f, 5f };
    public static float[] x_position = new float[2] { -13f, 13f };
    public static float[] x_force = new float[8] { 10f, 12.5f, 15f, 20f, -10f, -12.5f, -15f, -20f };

    // 设定飞碟工厂的上游场景控制器
    public void SetDepend(SceneController firstCtrl)
    {
        this.myController = firstCtrl;
    }


    public void InitializeUFO()
    {
        if (mCoroutine != null)
        {
            StopCoroutine(mCoroutine);
            mCoroutine = null;
        }
        for (int i = 0; i < trial; i++)
        {
            if (UFOs[i] != null)
            {
                Destroy(UFOs[i].ufoObject);
            }
            UFOs[i] = new UFO(this, i);
            UFOs[i].SetUFOActive(false);
        }
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    // 在一定时间间隔内启动一系列UFO对象的飞行
    IEnumerator SetUFOStart(float gapTime)
    {
        for (int i = 0; i < trial; ++i)
        {
            int side = Random.Range(0, 2);
            UFOs[i].SetUFOActive(true);
            // 设置UFO的飞行参数，包括颜色、缩放大小、位置和力的方向
            UFOs[i].Fly(colors[Random.Range(0, 5)], scales[Random.Range(0, 5)] * gapTime, new Vector3(x_position[side], y_position[Random.Range(0, 5)], 0), new Vector3(x_force[Random.Range(0, 4) + side * 4], 0, 0));
            yield return new WaitForSeconds(gapTime);
        }
    }

    public void StartRound()
    {
        mCoroutine = StartCoroutine(SetUFOStart(2f - difficulty * 0.2f));
    }

    public bool CheckRoundFinish()
    {
        for (int i = 0; i < trial; i++)
        {
            if (!UFOs[i].isOver)
            {
                return false;
            }
        }
        return true;
    }

    public void ClickUFO(int id)
    {
        UFOs[id].SetUFOActive(false);
        myController.AddScore();
        if (CheckRoundFinish())
        {
            if (mCoroutine != null)
            {
                StopCoroutine(mCoroutine);
                mCoroutine = null;
            }
            myController.RoundDone();
        }
    }

    public void FailUFO(int id)
    {
        UFOs[id].SetUFOActive(false);
        myController.SubBlood();
        if (CheckRoundFinish())
        {
            if (mCoroutine != null)
            {
                StopCoroutine(mCoroutine);
                mCoroutine = null;
            }
            myController.RoundDone();
        }
    }
}