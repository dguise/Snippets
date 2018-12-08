using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterSeconds : MonoBehaviour
{
    [Tooltip("Enables all child objects after set time")]
    [SerializeField]
    [Range(0, 60)]
    private float seconds;

    [Tooltip("Disables all children OnValidate, can be done manually through ContextMenuItem on this property as well.")]
    [SerializeField]
    [ContextMenuItem("Disable children", "DisableChildren")]
    private bool AutoDisableChildrenInEditor = true;

    private void OnValidate()
    {
        gameObject.name = "After " + seconds + " seconds";
        ToggleChildren(AutoDisableChildrenInEditor);
    }

    void Start()
    {
        StartCoroutine(EnableChildren());
    }




    IEnumerator EnableChildren()
    {
        yield return new WaitForSeconds(seconds);
        ToggleChildren(true);
    }

    void DisableChildren()
    {
        ToggleChildren(false);
    }

    void ToggleChildren(bool setTo)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(setTo);
        }
    }
}
