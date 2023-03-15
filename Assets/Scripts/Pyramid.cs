using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : Shape
{
    public string shapeName
    {
        get {return m_shapeName;}
        set {
            if(value[0] != 'P') {
                Debug.LogError("Pyramid name must start with a P.");
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
        shapeRb.AddTorque(10, 0, 0);
    }

    public override void ChangeName(string newName)
    {
        shapeName = newName;
    }
}
