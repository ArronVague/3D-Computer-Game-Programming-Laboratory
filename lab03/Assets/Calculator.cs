using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private string expression;
    private char[,] keyboard = { { 'C', 'X', '%', '¡Â' }, { '7', '8', '9', '¡Á' }, { '4', '5', '6', '-' }, { '1', '2', '3', '+' }, { 'e', '0', '.', '=' } };
    private Stack<double> num = new Stack<double>();
    private Stack<char> op = new Stack<char>();
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(245, 5, 300, 500), "");
        GUI.Button(new Rect(255, 10, 280, 70), expression);
        GUI.Button(new Rect(255, 80, 280, 70), num.Peek().ToString());
        for (int i = 0; i < keyboard.GetLength(0); ++i)
        {
            for (int j = 0; j < keyboard.GetLength(1); ++j)
            {
                if (keyboard[i, j] == 'C' && GUI.Button(new Rect(255 + j * 70, 50 + i * 70 + 100, 70, 70), keyboard[i, j].ToString()))
                {
                    Clear();
                }

                else if (GUI.Button(new Rect(255 + j * 70, 50 + i * 70 + 100, 70, 70), keyboard[i, j].ToString()))
                {
                    Input(i, j);
                    Debug.Log(keyboard[i, j]);
                }
            }
        }
    }

    void Init()
    {
        Clear();
    }

    void Input(int i, int j)
    {
        expression += keyboard[i, j];   
    }

    void Clear()
    {
        num.Clear();
        num.Push(0);
        op.Clear();
        expression = "";
    }
}
