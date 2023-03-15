using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    public string shapeName
    {
        get {return m_shapeName;}
        set {
            if(value[0] != 'S') {
                Debug.LogError("Sphere name must start with an S.");
            }
            else {
                m_shapeName = value;
            }
        }
    }

    public override void Selected()
    {

    }

    public override void ShapeRotation()
    {
        shapeRb.AddTorque(0, 10, 0);
    }

    public override void ChangeName(string newName)
    {
        shapeName = newName;
    }
}
