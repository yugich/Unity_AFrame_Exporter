using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAFrameObject : AFrameObject
{
    public enum LIGHT_TYPE
    {
        AMBIENT,
        DIRECTIONAL,
        HEMISPHERE,
        POINT,
        SPOT
    }

    
    public LIGHT_TYPE type = LIGHT_TYPE.DIRECTIONAL;
    public Color color = Color.white;
    public float intensity = 1f;
    public bool castShadow = true;
    public override string GetExtraAFrameCommand()
    {
        string newCommand = "";

        if (castShadow)
        {
            newCommand = string.Format(" light = \"type: {0}; color: #{1}; intensity: {2}; castShadow:{3};\"", type.ToString().ToLower(), //0
                                                                                                                            ColorUtility.ToHtmlStringRGB(color), //1
                                                                                                                            intensity, //2
                                                                                                                            castShadow);//3
        }
        if (generalAFrameCommands.Contains(newCommand) == false)
        {
            generalAFrameCommands += newCommand;
        }

        return base.GetExtraAFrameCommand();
    }



}
