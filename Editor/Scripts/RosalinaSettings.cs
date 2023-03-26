using UnityEngine;

public class RosalinaSettings : ScriptableObject
{
    public string DefaultNamespace;
    public bool IsEnabled;
    public static RosalinaSettings GetInstance()
    {
        return Resources.Load<RosalinaSettings>("RosalinaSettings");
    }

}