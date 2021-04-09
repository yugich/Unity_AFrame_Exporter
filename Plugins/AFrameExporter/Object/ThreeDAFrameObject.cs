using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDAFrameObject : AFrameObject
{
    public bool receiveShadow = true;
    public GameObject customThreeD = null;

    public override string GetExtraAFrameCommand()
    {
        string newCommand = "";

        if (receiveShadow)
        {
            newCommand = " shadow = \"receive: true\"";
        }

        if(generalAFrameCommands.Contains(newCommand) == false)
            generalAFrameCommands += newCommand;

        return base.GetExtraAFrameCommand();
    }

    public override ExternalObject GetExternalAsset()
    {
        return new ExternalObject(ExternalObject.TYPE.ThreeD,customThreeD);
    }
}
