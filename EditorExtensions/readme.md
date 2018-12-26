From https://docs.unity3d.com/Manual/SpecialFolders.html

## Editor
Scripts placed in a folder called Editor are treated as Editor scripts rather than runtime scripts. These scripts add functionality to the Editor during development, and are not available in builds at runtime.

You can have multiple Editor folders placed anywhere inside the Assets folder. Place your Editor scripts inside an Editor folder or a subfolder within it.

The exact location of an Editor folder affects the time at which its scripts will be compiled relative to other scripts (see documentation on Special Folders and Script Compilation Order for a full description of this). Use the EditorGUIUtility.Load function in Editor scripts to load Assets from a Resources folder within an Editor folder. These Assets can only be loaded via Editor scripts, and are stripped from builds.

_Note: Unity does not allow components derived from MonoBehaviour to be assigned to GameObjects if the scripts are in the Editor folder._

## Editor Default Resources
Editor scripts can make use of Asset files loaded on-demand using the EditorGUIUtility.Load function. This function looks for the Asset files in a folder called Editor Default Resources.

You can only have one Editor Default Resources folder and it must be placed in the root of the Project; directly within the Assets folder. Place the needed Asset files in this Editor Default Resources folder or a subfolder within it. Always include the subfolder path in the path passed to the EditorGUIUtility.Load function if your Asset files are in subfolders.
