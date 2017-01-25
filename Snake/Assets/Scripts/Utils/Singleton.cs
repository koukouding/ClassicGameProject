using UnityEngine;
using System.Collections;

/// <summary>
/// 单例方法封装成一个类
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {

            if (!_instance)
            {
                _instance = (T) FindObjectOfType(typeof(T));
            }

            return _instance;
        }
    }

    protected static T _instance;
}


//用法:
//1.继承
//public class SnakeMannager : Singleton<SnakeMannager>
//2.
//SnakeMannager.Instance