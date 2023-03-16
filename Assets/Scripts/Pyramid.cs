using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Pyramid : Shape
{
    // ENCAPSULATION
    public string shapeName
    {
        get {return m_shapeName;}
        set {
            if(value[0] != 'P') {
                Debug.LogError("Pyramid name must start with a P.");
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
        shapeName = "Pyramid";
    }

    // POLYMORPHISM
    public override void ShapeRotation()
    {
        shapeRb.AddTorque(10, 0, 0);
    }

    // POLYMORPHISM
    public override void ChangeName(string newName)
    {
        if(newName != ""){
            shapeName = newName;
        }
    }

    // POLYMORPHISM
    public override string getName()
    {
        return shapeName;
    }

    // POLYMORPHISM
    public override string getSalutation()
    {
        return $"Hi, it's {shapeName}!";
    }
}
