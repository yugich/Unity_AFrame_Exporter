using UnityEngine;
using UnityEditor;

public class AFrameExporter : EditorWindow
{
    bool useDataPath = true;
    static string pathToSave = "";
    string fileName = "";
    [MenuItem("Window/A-FrameExporter")]
    static void Init()
    {
        pathToSave = PlayerPrefs.GetString("LAST_PATH", "");
        AFrameExporter window = (AFrameExporter)EditorWindow.GetWindow(typeof(AFrameExporter));
        window.Show();
    }
    

    private void OnGUI()
    {
        
        GUILayout.Label("A-Frame script object position Exporter", EditorStyles.boldLabel);
        useDataPath = EditorGUILayout.Toggle("Use DataPath", useDataPath);
        pathToSave = EditorGUILayout.TextField("Path to Save", pathToSave);
        fileName = EditorGUILayout.TextField("File Name", fileName);
        if (GUILayout.Button("Export"))
        {
            PlayerPrefs.SetString("LAST_PATH", pathToSave);
            string pathTemp = pathToSave;
            if (useDataPath == true)
            {
                pathTemp = Application.dataPath + "/" + pathTemp;
            }
            TextFileExporter.SaveTextFile(pathTemp, fileName, SceneObjectsConverter.GetAFrameCode());

            ShowNotification(new GUIContent("Completed"));
        }

        GUILayout.Label("Created by www.caiohv.com", EditorStyles.boldLabel);
    }

}
