using UnityEngine;
using UnityEditor;

public class CustomInspectorExampleComponent : MonoBehaviour
{
    public string ExampleString = "1337";
}

[CustomEditor(typeof(CustomInspectorExampleComponent))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CustomInspectorExampleComponent ciec = (CustomInspectorExampleComponent) target;

        GUILayout.BeginHorizontal();
        GUILayout.Label("Print stuff: ");
        if (GUILayout.Button("Click me!"))
        {
            Debug.Log(ciec.ExampleString);
        }
        GUILayout.EndHorizontal();
    }
}
