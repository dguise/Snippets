using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Settings {
    public string Name;
}

public static class Global
{
    public static Settings Settings = new Settings
    {
        // Default settings, globally accessed through Global.Settings
        Name = "Maakep",
    };
}

/*

SettingsImporter.TryOverwriteSettingsWithWebSettings(this, (bool success) =>
{
    // Do something when we're done downloading
});
 
*/
public static class SettingsImporter
{
    public static string Url = "localhost:3000";

    private const string ERROR = "ErrorFetchingJsonData";
    public static void TryOverwriteSettingsWithWebSettings(MonoBehaviour any, Action<bool> Done)
    {
        any.StartCoroutine(GetJson((string result) =>
        {
            var success = (result != ERROR);
            if (success)
                Global.Settings = JsonUtility.FromJson<Settings>(result);

            Done(success);
        }));
    }

    public static string GetSettingsJsonString()
    {
        return JsonUtility.ToJson(Global.Settings);
    }

    static IEnumerator GetJson(Action<string> Callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Callback(ERROR);
            }
            else
            {
                string result = www.downloadHandler.text;
                Callback(result);
            }
        }
    }
}
