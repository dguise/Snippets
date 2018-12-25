using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : Singleton<FadeManager>
{
    Image fadeImage;
    private Color invisible = new Color(0, 0, 0, 0);
    private Color visible = new Color(0, 0, 0, 1);
    private Coroutine fadeRoutine = null;

    [SerializeField] [Range(0.1f, 2f)] private float speed = 1;

    void OnValidate() 
    {
        // For easier development
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Start() 
    {
        // For easier development
        transform.GetChild(0).gameObject.SetActive(true);

        fadeImage = GetComponentInChildren<Image>();
        FadeIn();
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene active, Scene next)
    {
        FadeIn();
    }

    void LoadNextScene() 
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene > SceneManager.sceneCountInBuildSettings - 1) 
            nextScene = 0;

        SceneManager.LoadScene(nextScene);
    }

    public void FadeToNextScene()
    {
        FadeOut(() => {
            LoadNextScene();
        });
    }

    public void FadeOut(Action doneCallback = null)
    {
        if (fadeRoutine == null)
            fadeRoutine = StartCoroutine(_FadeOut(doneCallback));
    }
    private IEnumerator _FadeOut(Action doneCallback)
    {
        float tick = 0f;
        while (fadeImage.color != visible)
        {
            tick += Time.deltaTime * speed;
            fadeImage.color = Color.Lerp(invisible, visible, tick);
            yield return new WaitForEndOfFrame();
        }

        if (doneCallback != null)
            doneCallback();
        fadeRoutine = null;
    }

    public void FadeIn(Action doneCallback = null)
    {
        if (fadeRoutine == null)
            fadeRoutine = StartCoroutine(_FadeIn(doneCallback));
    }
    private IEnumerator _FadeIn(Action doneCallback)
    {
        float tick = 0f;
        while (fadeImage.color != invisible)
        {
            tick += Time.deltaTime * speed;
            fadeImage.color = Color.Lerp(visible, invisible, tick);
            yield return new WaitForEndOfFrame();
        }

        if (doneCallback != null)
            doneCallback();
        fadeRoutine = null;
    }
}
