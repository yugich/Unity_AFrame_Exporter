using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsConverter
{
    

    public static string GetAFrameCode()
    {
        string result = "";

        AFrameObject[] allAFramebjects = Object.FindObjectsOfType<AFrameObject>();

        result += "<html>\n\n" +
            "<head>\n" +
            "   <script src = \"https://aframe.io/releases/1.2.0/aframe.min.js\" ></script>\n" +
            "</head>\n\n" +
            "<body>\n" +
            "   <a-scene>\n";

        foreach(AFrameObject aframeObj in allAFramebjects)
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


                result += string.Format("       <{0} id=\"{1}\" position=\"{2} {3} {4}\" rotation=\"{5} {6} {7}\" scale=\"{8} {9} {10}\" {11} {12}></{0}>\n", aframeObj.objType,
                                                                                             aframeObj.gameObject.name.Replace(' ','_'),
                                                                                             (aframeObj.transform.position.x * -1).ToString().Replace(",", "."), aframeObj.transform.position.y.ToString().Replace(",", "."), aframeObj.transform.position.z.ToString().Replace(",", "."),
                                                                                             aframeObj.transform.eulerAngles.x.ToString().Replace(",", "."), (aframeObj.transform.eulerAngles.y + 180).ToString().Replace(",", "."), aframeObj.transform.eulerAngles.z.ToString().Replace(",", "."),
                                                                                             (aframeObj.transform.lossyScale.x).ToString().Replace(",", "."), (aframeObj.transform.lossyScale.y).ToString().Replace(",", "."), (aframeObj.transform.lossyScale.z).ToString().Replace(",", "."),
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



}
