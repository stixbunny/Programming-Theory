using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    public string shapeName
    {
        get {return m_shapeName;}
        set {
            if(value[0] != 'C') {
                Debug.LogError("Cube name must start with a C.");
            }
            else {
                m_shapeName = value;
            }
        }
    }

    private void Start() {
        
        ShapeRotation();
    }

    public override void Selected()
    {

    }

    public override void ShapeRotation()
    {
        shapeRb.AddTorque(10, 10, 0);
    }

    public override void ChangeName(string newName)
    {
        shapeName = newName;
    }
}
