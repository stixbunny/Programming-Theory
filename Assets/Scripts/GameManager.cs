using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    private bool isGameStarted = false;
    private Camera cam;
    public Shape selectedShape = null;
    private PopUpMenuHandler popUpHandler;
    public static GameManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadScore();
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        cam = Camera.main;
        isGameStarted = true;
        GameObject popUp = GameObject.FindGameObjectWithTag("PopUp");
        popUpHandler = popUp.GetComponent<PopUpMenuHandler>();
        popUp.SetActive(false);
    }

    /*private void ExitGame()
    {

    } */

    private void Update()
    {
        if(isGameStarted) {
            if(Mouse.current.leftButton.wasPressedThisFrame) {
                SelectClick();
            }

        }
    }

    private void SelectClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(EventSystem.current.IsPointerOverGameObject()) {
            //UI click
        }
        else if(Physics.Raycast(ray, out hit)) {
            GameObject obj = hit.transform.gameObject;
            if(obj.GetComponent<Shape>() != selectedShape) {
                if(selectedShape) {
                    Deselect();
                }
                Select(obj.GetComponent<Shape>());
            }
        }
        else {
            if(selectedShape) {
                Deselect();
            }
        }
    }

    private void Select(Shape shape)
    {
        selectedShape = shape;
        shape.Selected();
        popUpHandler.Pop();
    }

    public void Deselect()
    {
        selectedShape.Deselect();
        selectedShape = null;
        popUpHandler.Hide();
    }
}
