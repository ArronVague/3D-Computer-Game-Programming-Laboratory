using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    // Entities and their states / Model
    // 模型只能包含游戏对象数据
    private string expression;
    private char[,] keyboard = { { 'C', 'X', '%', '÷' }, { '7', '8', '9', '×' }, { '4', '5', '6', '-' }, { '1', '2', '3', '+' }, { 'e', '0', '.', '=' } };
    private Stack<int> num = new Stack<int>();
    private char preSign;
    private int init_num;
    private string result;

    // System Handlers
    void Start()
    {
        Init();
    }

    // View render entities / models
    // Here! you cannot modify model directly, use components/controls to do it
    void OnGUI()
    {
        GUI.Box(new Rect(245, 5, 300, 500), "");
        GUI.Button(new Rect(255, 10, 280, 70), expression);
        GUI.Button(new Rect(255, 80, 280, 70), result);
        for (int i = 0; i < keyboard.GetLength(0); ++i)
        {
            for (int j = 0; j < keyboard.GetLength(1); ++j)
            {
                char cur_c = keyboard[i, j]; 
                if (cur_c == 'C' && GUI.Button(new Rect(255 + j * 70, 50 + i * 70 + 100, 70, 70), cur_c.ToString()))
                {
                    Clear();
                }
                else if (cur_c == '=' && GUI.Button(new Rect(255 + j * 70, 50 + i * 70 + 100, 70, 70), cur_c.ToString()))
                {
                    Calculate();
                }
                else if (GUI.Button(new Rect(255 + j * 70, 50 + i * 70 + 100, 70, 70), cur_c.ToString()))
                {
                    Input(cur_c);
                    Debug.Log(cur_c);
                }
            }
        }
    }

    // Components
    // here! any ui can not be referenced
    // 模型对象（数据）的基本操作逻辑
    void Init()
    {
        Clear();
    }

    // 输入表达式
    void Input(char cur_c)
    {
        expression += cur_c;   
    }

    // 通过表达式计算结果
    void Calculate()
    {
        int n = expression.Length;
        for (int i = 0; i < n; ++i) {
            char c = expression[i];
            if (char.IsDigit(c))
            {
                init_num = init_num * 10 + c - '0';
            }
            if (!char.IsDigit(c) || i == n - 1)
            {
                switch (preSign)
                {
                    case '+':
                        num.Push(init_num);
                        break;
                    case '-':
                        num.Push(-init_num);
                        break;
                    case '×':
                        num.Push(num.Pop() * init_num);
                        break;
                    default:
                        num.Push(num.Pop() / init_num);
                        break;
                }
                preSign = c;
                init_num = 0;
            }
        }
        int res = 0;
        while (num.Count > 0)
        {
            res += num.Pop();
        }
        result = res.ToString();
    }

    // 重置变量和数据结构
    void Clear()
    {
        num.Clear();
        expression = "";
        result = "";
        init_num = 0;
        preSign = '+';
    }
}
