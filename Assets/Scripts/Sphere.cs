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
            else if(value.Length > 10) {
                Debug.LogError("Name must not exceed 10 characters");
            }
            else {
                m_shapeName = value;
            }
        }
    }

    private void Start()
    {
        shapeName = "Sphere";
        
    }

    public override void ShapeRotation()
    {
        shapeRb.AddTorque(0, 10, 0);
    }

    public override void ChangeName(string newName)
    {
        if(newName != ""){
            shapeName = newName;
        }
    }

    public override string getName()
    {
        return shapeName;
    }

    public override string getSalutation()
    {
        return $"Howdy, {shapeName} here!";
    }
}
