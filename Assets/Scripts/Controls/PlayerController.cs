using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isMounted = false;
    public Interactable focus;
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
    Mountable mount = null;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                if (isMounted)
                {
                    mount.MoveToPoint(hit.point);
                }
                else
                {
                    // Move our player to what we hit
                    motor.MoveToPoint(hit.point);
                }

                // Stop focusing on any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                // Check if we hit an interactable
                // If so, set it as our focus.
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Unmount();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        Unmount();

        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    public void Mount(Mountable newParent)
    {
        mount = newParent;

        transform.parent = mount.transform;
        transform.position = mount.transform.position;
        transform.rotation = mount.transform.rotation;

        motor.StartMounting();
        RemoveFocus();

        isMounted = true;
    }

    public void Unmount()
    {
        mount = null;

        transform.parent = null;
        motor.StopMounting();

        isMounted = false;
    }
}

