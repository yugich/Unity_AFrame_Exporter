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
    Object customThreeD = null;

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
        }

        if (GUILayout.Button("Create Sphere"))
        {
        }

        if (GUILayout.Button("Create Cylinder"))
        {
        }

        if (GUILayout.Button("Create Plane"))
        {
        }
        EditorGUILayout.Space();
        GuiLine();
        EditorGUILayout.Space();
        GUILayout.Label("Custom 3D", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        customThreeD = (Object)EditorGUILayout.ObjectField("Custom 3D Object",customThreeD, typeof(Object), false);
        customObjectReceiveShadow = EditorGUILayout.Toggle("Receive Shadow:", customObjectReceiveShadow);
        if (GUILayout.Button("Create Custom Object"))
        {
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

}
