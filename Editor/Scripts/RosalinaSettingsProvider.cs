#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class RosalinaSettingsProvider : SettingsProvider
{
    private RosalinaSettings rosalinaSettings;

    public RosalinaSettingsProvider(string path, SettingsScope scope) : base(path, scope) { }

    [SettingsProvider]
    public static SettingsProvider CreateRosalinaSettingsProvider()
    {
        return new RosalinaSettingsProvider("Project/Rosalina", SettingsScope.Project);
    }

    public override void OnGUI(string searchContext)
    {
        if (rosalinaSettings == null)
        {
            rosalinaSettings = Resources.Load<RosalinaSettings>("RosalinaSettings");

            // Create the ScriptableObject if it doesn't exist
            if (rosalinaSettings == null)
            {
                CreateRosalinaSettingsAsset();
                rosalinaSettings = Resources.Load<RosalinaSettings>("RosalinaSettings");
            }
        }

        EditorGUI.BeginChangeCheck();

        rosalinaSettings.DefaultNamespace = EditorGUILayout.TextField("Default Namespace", rosalinaSettings.DefaultNamespace);
        rosalinaSettings.IsEnabled = EditorGUILayout.Toggle("Is Enabled", rosalinaSettings.IsEnabled);

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(rosalinaSettings);
        }
    }

    private void CreateRosalinaSettingsAsset()
    {
        string resourcePath = "Assets/Resources";
        if (!AssetDatabase.IsValidFolder(resourcePath))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
        }

        RosalinaSettings newSettings = ScriptableObject.CreateInstance<RosalinaSettings>();
        AssetDatabase.CreateAsset(newSettings, $"{resourcePath}/RosalinaSettings.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif