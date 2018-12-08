using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnykeyNextScene : MonoBehaviour 
{
	private bool _notRunOnce = true;
    
	void Update () 
    {
        if (Input.anyKeyDown && _notRunOnce) 
        {
            FadeManager.Instance.FadeToNextScene();
            // If FadeManager isn't used:
            // LoadNextScene();
        }
	}

    void LoadNextScene() 
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene > SceneManager.sceneCountInBuildSettings - 1) 
            nextScene = 0;

        SceneManager.LoadScene(nextScene);
        _notRunOnce = false;
    }
}
