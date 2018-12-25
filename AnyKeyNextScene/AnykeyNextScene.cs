using UnityEngine;
using UnityEngine.SceneManagement;

public class AnykeyNextScene : MonoBehaviour
{
    private static bool _notRunOnce = true;

    void Update()
    {
        if (Input.anyKeyDown && _notRunOnce)
        {
            _notRunOnce = false;
            FadeManager.Instance.FadeToNextScene();
            // If FadeManager isn't used:
            // LoadNextScene();
        }
    }

    public static void LoadNextScene()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene > SceneManager.sceneCountInBuildSettings - 1)
            nextScene = 0;

#if UNITY_EDITOR
        nextScene = RuntimeInitializer.startedScene != -1 ? RuntimeInitializer.startedScene : nextScene;
#endif
        SceneManager.LoadScene(nextScene);
    }
}
