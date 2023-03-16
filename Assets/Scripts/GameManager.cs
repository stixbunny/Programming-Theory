using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 1) {
            cam = Camera.main;
            isGameStarted = true;
            GameObject popUp = GameObject.FindGameObjectWithTag("PopUp");
            popUpHandler = popUp.GetComponent<PopUpMenuHandler>();
            popUp.SetActive(false);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ABSTRACTION
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // ABSTRACTION
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }

    private void Update()
    {
        if(isGameStarted) {
            if(Mouse.current.leftButton.wasPressedThisFrame) {
                // ABSTRACTION
                SelectClick();
            }

        }
    }

    // ABSTRACTION
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
                    // ABSTRACTION
                    Deselect();
                }
                Select(obj.GetComponent<Shape>());
            }
        }
        else {
            if(selectedShape) {
                // ABSTRACTION
                Deselect();
            }
        }
    }

    // ABSTRACTION
    private void Select(Shape shape)
    {
        selectedShape = shape;
        shape.Selected();
        popUpHandler.Pop();
    }

    // ABSTRACTION
    public void Deselect()
    {
        selectedShape.Deselect();
        selectedShape = null;
        popUpHandler.Hide();
    }
}
