using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFrameObject : MonoBehaviour
{

    public bool receiveShadow = false;
    [SerializeField] string generalAFrameCommands = "";
    public string objType = "a-entity";


    public virtual string GetExtraAFrameCommand()
    {
        if (receiveShadow)
        {
            generalAFrameCommands += " shadow = \"receive: true\"";
        }
        return generalAFrameCommands;
    }

    public virtual string GetAllCustomScript()
    {
        return "";
    }

}
