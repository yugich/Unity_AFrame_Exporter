using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SceneObjectsConverter
{
    

    public static string GetAFrameCode(string fullProjectPath)
    {
        string result = "";

        AFrameObject[] allAFramebjects = Object.FindObjectsOfType<AFrameObject>();

        result += "<html>\n\n" +
                    "<head>\n" +
                    "   <script src = \"https://aframe.io/releases/1.2.0/aframe.min.js\" ></script>\n" +
                    "</head>\n\n" +
                    "<body>\n" +
                    "   <a-scene>\n"+
                    "       <a-assets>\n";
        ThreeDAFrameObject[] allCustom3D = Object.FindObjectsOfType<ThreeDAFrameObject>();
        foreach(ThreeDAFrameObject custom3d in allCustom3D)
        {
            if(custom3d.GetExternalAsset().obj != null)
            {
                string objExtension = custom3d.GetExternalAsset().obj.name;
                if (objExtension.Contains(".gltf") == false)
                {
                    objExtension += ".gltf";
                }

                result += string.Format("           <a-asset-item id=\"{0}\" src=\"/Assets/3D/{1}\"></a-asset-item>\n", custom3d.GetExternalAsset().obj.name.Replace(".gltf", ""),
                                                                                                                    objExtension);

                string prefabPath = AssetDatabase.GetAssetPath(custom3d.GetExternalAsset().obj);
                string destinationCopy = fullProjectPath + "/Assets/3D/" + objExtension;
                try
                {
                    FileUtil.CopyFileOrDirectory(prefabPath, destinationCopy);
                }
                catch (System.Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
            }
        }

        result += "       </a-assets>\n";

        foreach (AFrameObject aframeObj in allAFramebjects)
        {
            if(aframeObj.GetAllCustomScript() == "")
            {
                Renderer rendererTemp = aframeObj.gameObject.GetComponent<Renderer>();
                string colorText = "";

                if(rendererTemp != null)
                {
                    Material materialTemp = aframeObj.gameObject.GetComponent<Renderer>().sharedMaterial;
                    if(materialTemp != null)
                    {
                        colorText = string.Format("color=\"#{0}\"", ColorUtility.ToHtmlStringRGB(materialTemp.color));
                    }
                
                }

                
                result += string.Format("       <{0} {1} id=\"{2}\" position=\"{3} {4} {5}\" rotation=\"{6} {7} {8}\" scale=\"{9} {10} {11}\" {12} {13}></{0}>\n", aframeObj.objType,
                                                                                             GetExternalAsset(aframeObj),
                                                                                             "id_"+ aframeObj.gameObject.name.Replace(' ', '_'),
                                                                                             (aframeObj.transform.position.x * -1).ToString().Replace(",", "."), aframeObj.transform.position.y.ToString().Replace(",", "."), aframeObj.transform.position.z.ToString().Replace(",", "."),
                                                                                             (aframeObj.transform.eulerAngles.x - (aframeObj.objType.Contains("a-plane") == true ? 90 : 0)).ToString().Replace(",", "."), (aframeObj.transform.eulerAngles.y +(GetExternalAsset(aframeObj) == "" ? 180 : 0)).ToString().Replace(",", "."), aframeObj.transform.eulerAngles.z.ToString().Replace(",", "."),
                                                                                             (aframeObj.transform.lossyScale.x * (aframeObj.objType.Contains("a-plane") == true ? 10 : (aframeObj.objType.Contains("a-cylinder") == true ? 0.6f : 1))).ToString().Replace(",", "."), (aframeObj.transform.lossyScale.y * (aframeObj.objType.Contains("a-plane") == true ? 10 : (aframeObj.objType.Contains("a-cylinder") == true ? 3.3f : 1))).ToString().Replace(",", "."), (aframeObj.transform.lossyScale.z * (aframeObj.objType.Contains("a-plane") == true ? 10 : (aframeObj.objType.Contains("a-cylinder") == true ? 0.6f : 1))).ToString().Replace(",", "."),
                                                                                             colorText,
                                                                                             aframeObj.GetExtraAFrameCommand());
                
                
                
            }
            else
            {
                result += aframeObj.GetAllCustomScript();
            }

        }

        result+= "   </a-scene>\n" +
            "</body>\n\n" +
            "</html>";

        Debug.Log(result);

        return result;
    }

    private static string GetExternalAsset(AFrameObject aframeObj)
    {
        if(aframeObj.GetExternalAsset() == null || aframeObj.GetExternalAsset().obj == null)
        {
            return "";
        }

        string result = "";
        if(aframeObj.GetExternalAsset().type == AFrameObject.ExternalObject.TYPE.ThreeD)
        {
            result += string.Format("gltf-model=\"#{0}\"", aframeObj.GetExternalAsset().obj.name.Replace(".gltf", ""));
        }

        return result;
    }

}
