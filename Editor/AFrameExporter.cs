using UnityEngine;
using UnityEditor;

public class AFrameExporter : EditorWindow
{
    bool useDataPath = true;
    static string pathToSave = "";
    string fileName = "index";

    private string assetsPath = "";
    private string three3DPath = "";
    private string imagesPath = "";


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


            CreateAllFolders(pathTemp);


            TextFileExporter.SaveTextFile(pathTemp, fileName, SceneObjectsConverter.GetAFrameCode(pathTemp));

            ShowNotification(new GUIContent("Completed"));
        }

        GUILayout.Label("Created by mimic.land", EditorStyles.boldLabel);
    }

    private void CreateAllFolders(string path)
    {
        //-------------Main Path---------------
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }

        //-------------Assets Folder---------------
        assetsPath = path + "/Assets";

        if (!System.IO.Directory.Exists(assetsPath))
        {
            System.IO.Directory.CreateDirectory(assetsPath);
        }

        //-------------3D Folder---------------
        three3DPath = assetsPath + "/3D";
        if (!System.IO.Directory.Exists(three3DPath))
        {
            System.IO.Directory.CreateDirectory(three3DPath);
        }

        //------------Images Folder------------
        imagesPath = assetsPath + "/images";
        if (!System.IO.Directory.Exists(imagesPath))
        {
            System.IO.Directory.CreateDirectory(imagesPath);
        }

    }


}


 