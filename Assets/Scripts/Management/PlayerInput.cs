using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Start()
    {
        Debug.Log("damn");
        LockMouse();
    }

    void LateUpdate()
    {
        LockControl();
    }

    void LockControl()
    {
        if (Input.GetKey(KeyCode.Escape))
            UnlockMouse();
        else if (Input.GetKey(KeyCode.L))
            LockMouse();
    }

    void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
