using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDAFrameObject : AFrameObject
{
    public bool receiveShadow = true;
    public GameObject customThreeD = null;

    public override string GetExtraAFrameCommand()
    {
        if (receiveShadow)
        {
            generalAFrameCommands += " shadow = \"receive: true\"";
        }

        return base.GetExtraAFrameCommand();
    }

    public override ExternalObject GetExternalAsset()
    {
        return new ExternalObject(ExternalObject.TYPE.ThreeD,customThreeD);
    }
}
