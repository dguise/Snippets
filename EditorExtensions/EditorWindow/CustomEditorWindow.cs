using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class CustomEditorWindow : EditorWindow
{
    string text;

    [MenuItem("## DGUISE ##/Example")]
    public static void ShowWindow()
    {
        GetWindow<CustomEditorWindow>();
    }

    private void OnGUI()
    {
        GUILayout.Label("Some text", EditorStyles.centeredGreyMiniLabel);
        text = EditorGUILayout.TextField("Text field: ", text);

        if (GUILayout.Button("Click me!"))
        {
            Debug.Log("You wrote: " + text);

            // The Selection class gives you access to the selection
            Debug.Log("Selected game objects: " + string.Join(",", Selection.gameObjects.Select(x => x.name).ToArray()));
        }
    }
}
