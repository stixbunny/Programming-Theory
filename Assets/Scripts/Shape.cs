using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public GameManager gameManager;
    private Outline outline;
    protected Rigidbody shapeRb;
    protected string m_shapeName;
    public bool isSelected;

    protected void Awake()
    {
        gameManager = GameManager.Instance;
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 10;
        shapeRb = GetComponent<Rigidbody>();
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

    public virtual void Selected()
    {

    }

    public virtual void ShapeRotation()
    {

    }

    public virtual void ChangeName(string newName)
    {

    }

}
