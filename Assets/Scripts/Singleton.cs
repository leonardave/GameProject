using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> where T: class, new ()
{
    private static T instance;

    public static T GetInstance()
    {
        lock (typeof(T))
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;
        }
    }
}
