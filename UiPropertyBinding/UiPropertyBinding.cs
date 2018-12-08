using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPropertyBinding : MonoBehaviour
{
    Text ScoreText;
    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            ScoreText.text = _score.ToString();
        }
    }

    private void Start()
    {
        ScoreText = GetComponent<Text>();
        if (ScoreText == null)
            Debug.LogErrorFormat("No Text component found on GameObject {0}", gameObject.name);
    }
}
