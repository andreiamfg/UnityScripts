using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneById : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
