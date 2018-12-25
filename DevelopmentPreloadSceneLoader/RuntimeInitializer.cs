using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] is an attribute that makes sure this method when the game starts. 
/// Here we use it to start the preload scene.
/// </summary>
public class RuntimeInitializer
{
    public static int startedScene = -1;

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitLoadingScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0) return;

        startedScene = sceneIndex;

        Debug.Log("Loading preload scene");
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene(0);
    }

    // 
    private static void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (startedScene != -1 && scene.buildIndex == startedScene)
        {
            startedScene = -1;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }
    }
#endif
}
