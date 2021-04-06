using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFrameObject : MonoBehaviour
{
    public class ExternalObject
    {
        public enum TYPE
        {
            ThreeD,
            Image
        }

        public TYPE type;
        public Object obj;

        public ExternalObject(TYPE _type, Object _obj)
        {
            type = _type;
            obj = _obj;
        }
    }


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

    public virtual ExternalObject GetExternalAsset()
    {
        return null;
    }

}
