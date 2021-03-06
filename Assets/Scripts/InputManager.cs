﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{

    public static InputManager INSTANCE;

    public delegate void OnInteract();
    public OnInteract onInteract;

    public delegate void OnMainMouse();
    public OnMainMouse onMainMousePressed;
    public OnMainMouse onMainMouseClick;

    public delegate void OnMoveKeyPressed(Vector3 direction);
    public OnMoveKeyPressed onMoveKeyPressed;
    public OnMoveKeyPressed onChangedRotation;

    public delegate void OnArrowKey(int dir);
    public OnArrowKey onArrowKey;

    public delegate void OnMouseMoved(Vector2 mousePosition);
    public OnMouseMoved onMouseMoved;

    public delegate void OnSecondaryMouse(bool activated);
    public OnSecondaryMouse onSecondaryMousePressed;

    public delegate void OnTabPressed();
    public OnTabPressed onTabPressed;

    public delegate void OnShiftPressed(bool held);
    public OnShiftPressed onShiftPressed;

    public delegate void OnActivate();
    public OnActivate onActivate;


    public bool mainMouseHeld;
    public bool shiftHeld;

    public KeyCode interact = KeyCode.E;
    public KeyCode mainMouse = KeyCode.Mouse0;
    public KeyCode secondaryMouse = KeyCode.Mouse1;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode tabPressed = KeyCode.Tab;
    public KeyCode shift = KeyCode.LeftShift;
    public KeyCode activate = KeyCode.F;
    public KeyCode upArrow = KeyCode.UpArrow;
    public KeyCode downArrow = KeyCode.DownArrow;

    private void Awake()
    {
        if (INSTANCE)
        {
            Destroy(gameObject);
        }
        else
        {
            INSTANCE = this;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

        MainMouse();
        SecondaryMouse();
        TabPressed();
        Interact();
        MoveGetAxis();
        Activate();
        ShiftHeld();
        mainMouseHeld = MainMouseHeld();

    }

    private void ShiftHeld()
    {
        bool keyDown = Input.GetKeyDown(shift);
        bool keyUp = Input.GetKeyUp(shift);

        if (keyDown)
        {
            Debug.Log("Shift Pressed");
            onShiftPressed?.Invoke(true);
        }
        if (keyUp)
        {
            onShiftPressed?.Invoke(false);
        }
    }

    public void Interact()
    {
        if (Input.GetKeyDown(interact))
        {
            Debug.Log("Interact Key Pressed");
            onInteract?.Invoke();
        }
    }

    public void Activate()
    {
        if (Input.GetKeyDown(activate))
        {
            Debug.Log("Activate Pressed");
            onActivate?.Invoke();
        }
    }

    public void MainMouse()
    {
        bool clicked = Input.GetKeyDown(mainMouse);
        if (clicked)
        {
            Debug.Log("Main Mouse Pressed");
            onMainMouseClick?.Invoke();
        }
    }
    public bool MainMouseHeld()
    {
        bool pressed = Input.GetKey(mainMouse);
        if (pressed)
        {
            Debug.Log("Main Mouse Held");
            onMainMousePressed?.Invoke();
        }
        return pressed;
    }
    public void SecondaryMouse()
    {

        bool keyDown = Input.GetKeyDown(secondaryMouse);
        bool keyUp = Input.GetKeyUp(secondaryMouse);

        if (keyDown)
        {
            Debug.Log("Secondary Mouse Pressed");
            onSecondaryMousePressed?.Invoke(true);
        }
        if (keyUp)
        {
            onSecondaryMousePressed?.Invoke(false);
        }

    }

    public void MoveGetAxis()
    {

        Vector3 rotationVector = Vector3.zero;
        float x = 0;
        float z = 0;
        z = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");

        if (Input.GetKey(moveUp))
        {
            rotationVector += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(moveLeft))
        {
            rotationVector += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(moveDown))
        {
            rotationVector += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(moveRight))
        {

            rotationVector += new Vector3(1, 0, 0);
        }

        Vector3 direction = new Vector3(x, 0, z);

        if (direction != Vector3.zero)
        {
            Debug.Log("Move Key Direction: Pressed");
        }
        onMoveKeyPressed?.Invoke(direction);
        onChangedRotation?.Invoke(rotationVector);
    }

    public Vector3 GetMousePosition()
    {
        Vector3 VScreen = new Vector3();
        Vector3 positionPoint = new Vector3();

        VScreen.x = Input.mousePosition.x;
        VScreen.y = Input.mousePosition.y;
        VScreen.z = 10;
        positionPoint = Camera.main.ScreenToWorldPoint(VScreen);

        return positionPoint;
    }

    public void TabPressed()
    {
        if (Input.GetKeyDown(tabPressed))
        {
            Debug.Log("Tab Pressed");
            onTabPressed?.Invoke();
        }
    }

}



