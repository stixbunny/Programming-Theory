using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class PopUpMenuHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helloText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private UnityEngine.UI.Toggle whiteToggle;
    [SerializeField]
    private UnityEngine.UI.Toggle redToggle;
    [SerializeField]
    private UnityEngine.UI.Toggle greenToggle;
    [SerializeField]
    private UnityEngine.UI.Toggle blueToggle;
    [SerializeField]
    private UnityEngine.UI.Toggle yellowToggle;
    private int selectedColor;
    private Shape selectedShape = null;

    public void Hide()
    {
        selectedShape = null;
        gameObject.SetActive(false);
    }

    public void Pop()
    {
        selectedShape = GameManager.Instance.selectedShape;
        gameObject.SetActive(true);
        helloText.SetText(selectedShape.getSalutation());
        selectedColor = selectedShape.color;
        ChangeToggleColor(selectedColor);
        nameInput.text = "";
    }

    public void Save()
    {
        selectedShape.changeColor(selectedColor);
        selectedShape.ChangeName(nameInput.text);
        GameManager.Instance.Deselect();
    }

    // 0: white, 1: red, 2: green, 3: blue, 4: yellow
    public void ChangeColor(int color)
    {
        selectedColor = color;
    }

    // ABSTRACTION
    public void ChangeToggleColor(int color)
    {
        switch(color) {
            case 0:
                whiteToggle.isOn = true;
                break;
            case 1:
                redToggle.isOn = true;
                break;
            case 2:
                greenToggle.isOn = true;
                break;
            case 3:
                blueToggle.isOn = true;
                break;
            case 4:
                yellowToggle.isOn = true;
                break;
        }
    }
}
