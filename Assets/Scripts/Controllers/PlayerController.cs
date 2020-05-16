using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDead = false;
    public bool isMounted = false;
    public float mountRotationOffset = 90f;
    public float mountPositionOffset = 1f;
    public Interactable focus;
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
    Animator animator;
    Mountable mount = null;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() || isDead)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else if (Physics.Raycast(ray, out hit, 300, movementMask))
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
        animator.SetBool("isMounted", true);
        mount = newParent;

        transform.parent = mount.transform;
        transform.position = mount.transform.position + new Vector3(0, mountPositionOffset);
        transform.rotation = mount.transform.rotation * Quaternion.Euler(0, mountRotationOffset, 0);


        motor.StartMounting();
        RemoveFocus();

        isMounted = true;
    }

    public void Unmount()
    {
        animator.SetBool("isMounted", false);
        mount = null;

        transform.parent = null;
        motor.StopMounting();

        isMounted = false;
    }

    public void SetDead()
    {
        isDead = true;
    }
}

