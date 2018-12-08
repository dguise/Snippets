Use it by calling

```csharp
SettingsImporter.TryOverwriteSettingsWithWebSettings(this, (bool success) =>
{
    // Do something when we're done downloading
});
```


To get a preview of how the JSON the client expects from the server, run `GetSettingsJsonString()`