using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public GameManager gameManager;
    private Outline outline;
    protected Rigidbody shapeRb;
    protected string m_shapeName;
    public int color;
    public bool isSelected;

    protected void Awake()
    {
        gameManager = GameManager.Instance;
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 10;
        shapeRb = GetComponent<Rigidbody>();
        color = 0;
    }

    private void Update()
    {

    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void Selected()
    {
        shapeRb.isKinematic = false;
        ShapeRotation();
    }

    public void Deselect()
    {
        //shapeRb.freezeRotation = true;
        shapeRb.isKinematic = true;
    }

    // 0: white, 1: red, 2: green, 3: blue, 4: yellow
    public void changeColor(int color)
    {
        this.color = color;
        switch(color) {
            case 0:
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                break;
            case 1:
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                break;
            case 2:
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                break;
            case 3:
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                break;
            case 4:
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
    }


    public virtual void ShapeRotation()
    {

    }

    public virtual void ChangeName(string newName)
    {

    }

    public virtual string getName()
    {
        return null;
    }

    public virtual string getSalutation()
    {
        return null;
    }

}
