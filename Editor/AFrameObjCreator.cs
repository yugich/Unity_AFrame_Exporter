using UnityEngine;
using UnityEditor;

public class AFrameObjCreator : EditorWindow
{
    public enum LIGHT_TYPE
    {
        AMBIENT,
        DIRECTIONAL,
        HEMISPHERE,
        POINT,
        SPOT
    }
    bool primitiveReceiveShadow = true;

    bool customObjectReceiveShadow = true;
    GameObject customThreeD = null;

    public LIGHT_TYPE lightType = LIGHT_TYPE.DIRECTIONAL;
    Color lightColor = Color.white;
    float lightIntensity = 1f;
    bool lightCastShadow = true;
    [MenuItem("GameObject/A-Frame Obj Creator")]
    static void Init()
    {
        AFrameObjCreator window = (AFrameObjCreator)EditorWindow.GetWindow(typeof(AFrameObjCreator));
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("3D Object Creator", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        GuiLine();
        EditorGUILayout.Space();
        GUILayout.Label("Primitives", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        primitiveReceiveShadow = EditorGUILayout.Toggle("Receive Shadow:", primitiveReceiveShadow);
        if (GUILayout.Button("Create Cube"))
        {
            CreatePrimitive(PrimitiveType.Cube);
        }


        if (GUILayout.Button("Create Sphere"))
        {
            var result = CreatePrimitive(PrimitiveType.Sphere);
            result.generalAFrameCommands = "radius=\"0.5\"";
        }

        if (GUILayout.Button("Create Cylinder"))
        {
            CreatePrimitive(PrimitiveType.Cylinder);
        }

        if (GUILayout.Button("Create Plane"))
        {
            CreatePrimitive(PrimitiveType.Plane);
        }

        EditorGUILayout.Space();
        GuiLine();
        EditorGUILayout.Space();

        GUILayout.Label("Custom 3D", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        customThreeD = (GameObject)EditorGUILayout.ObjectField("Custom 3D Object",customThreeD, typeof(Object), false);
        customObjectReceiveShadow = EditorGUILayout.Toggle("Receive Shadow:", customObjectReceiveShadow);
        if (GUILayout.Button("Create Custom Object"))
        {
            CreateCustomObject(customThreeD);
        }

        EditorGUILayout.Space();
        GuiLine();
        EditorGUILayout.Space();

        GUILayout.Label("Light", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        lightType = (LIGHT_TYPE)EditorGUILayout.EnumPopup("Light Type:", lightType);
        lightColor = EditorGUILayout.ColorField("Light Color", lightColor);
        lightIntensity = EditorGUILayout.FloatField("Intensity:", lightIntensity);
        lightCastShadow = EditorGUILayout.Toggle("Cast Shadow", lightCastShadow);
        if (GUILayout.Button("Create Light"))
        {
        }

    }
    void GuiLine(int i_height = 1)
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height);
        rect.height = i_height;
        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
    }

    private ThreeDAFrameObject CreatePrimitive(PrimitiveType type)
    {
        GameObject primitive = GameObject.CreatePrimitive(type);
        ThreeDAFrameObject result = primitive.AddComponent<ThreeDAFrameObject>();
        result.objType = "a-" + type.ToString().ToLower();
        return result;
    }


    private void CreateCustomObject(GameObject obj)
    {
        GameObject newObj = Instantiate(obj);
        newObj.name = obj.name;
        ThreeDAFrameObject aframe = newObj.AddComponent<ThreeDAFrameObject>();
        aframe.objType = "a-entity";
        aframe.customThreeD = obj;
    }

}


