using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : MonoBehaviour
{
    // 单例模式，可以在任何代码中轻松获取单例对象
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)Object.FindObjectOfType(typeof(T));
                if (instance == null )
                {
                    Debug.LogError("Cannot find instance of " + typeof(T));
                }
            }
            return instance;
        }
    }
}