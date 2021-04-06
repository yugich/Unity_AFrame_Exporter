using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAFrameObject : AFrameObject
{
    public bool useMoveControls = true;
    public float acceleration = 100;

    public override string GetAllCustomScript()
    {
        string result = "";

        result += string.Format("       <a-entity id=\"camera_rig\" position=\"{0} {1} {2}\" rotation=\"{3} {4} {5}\">\n", (transform.position.x * -1).ToString().Replace(",","."),
                                                                                        transform.position.y.ToString().Replace(",", "."),
                                                                                        transform.position.z.ToString().Replace(",", "."),
                                                                                        transform.eulerAngles.x,
                                                                                        transform.eulerAngles.y + 180,
                                                                                        transform.eulerAngles.z);


        result += string.Format("           <{0} id=\"{1}\" camera {2} {3}></{0}>\n", objType,
                                                    gameObject.name.Replace(' ','_'),
                                                    useMoveControls ? "look-controls" : "",
                                                    useMoveControls ? ("wasd-controls=\"acceleration: " + acceleration+"\"") : "");

        result += "       </a-entity>\n";

        return result;
    }



}
