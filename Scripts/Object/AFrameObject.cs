using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFrameObject : MonoBehaviour
{

    public string generalAFrameCommands = "";
    public string objType = "a-entity";


    public virtual string GetExtraAFrameCommand()
    {
        return generalAFrameCommands;
    }

    public virtual string GetAllCustomScript()
    {
        return "";
    }

}
