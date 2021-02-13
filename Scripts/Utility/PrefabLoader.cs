using UnityEngine;
using System.Collections;
using System;

public class PrefabLoader : MonoBehaviour 
{
    public static T LoadPrefab<T> (string path) where T : MonoBehaviour
    {
        T prefab = null;

        GameObject obj = GameObject.Instantiate(LoadPrefab(path));

        if (obj != null)
        {
            prefab = obj.GetComponent<T>();
        }

        if (prefab == null)
        {
            Debug.LogError("Object at path: " + path + " is not of type " + prefab.GetType().ToString()); 
        }

        return prefab;
    }

    public static GameObject LoadPrefab (string path)
    {
        GameObject obj = Resources.Load(path) as GameObject;

        if (obj == null)
        {
            Debug.LogError("Object at path: " + path + " not found"); 
        }

        return obj;
    }
}
