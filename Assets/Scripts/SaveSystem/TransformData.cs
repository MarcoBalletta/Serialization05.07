using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class TransformData : GameData
{
    public string name;
    //public float x;
    //public float y;
    //public float z;

    //public float xRot;
    //public float yRot;
    //public float zRot;
    //public float wRot;

    public Vector3 position;
    public Quaternion rotation;

    //public Vector3 Position
    //{
    //    get => position; 
    //    set
    //    {
    //        position = value;
    //        //ToFloats();
    //    }
    //}
    //public Quaternion Rotation
    //{
    //    get => rotation;
    //    set
    //    {
    //        rotation = value;
    //        //ToFloatsRot();
    //    }
    //}

    public TransformData()
    {
        name = "";
        position = Vector3.zero +Vector3.up;
        rotation = Quaternion.identity;
    }

    //public void ToVector3()
    //{
    //    position = new Vector3(x, y, z);
    //}

    //public void ToFloats()
    //{
    //    x = position.x;
    //    y = position.y;
    //    z = position.z;
    //}

    //public void ToFloatsRot()
    //{
    //    xRot = rotation.x;
    //    yRot = rotation.y;
    //    zRot = rotation.z;
    //    wRot = rotation.w;
    //}

    //public void ToQuaternion()
    //{
    //    rotation = new Quaternion(xRot, yRot, zRot, wRot);
    //}
}

