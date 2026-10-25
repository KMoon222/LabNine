using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    public InputActionMap gameplayActions;
    private InputAction moveAction;

    private List<GameObject> bullets = new List<GameObject>();

    void Awake()
    {
        moveAction = new InputAction("Move", InputActionType.Value, expectedControlType: "Vector2");
        moveAction.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s").With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");

        GameObject[] bulletsArray = GameObject.FindGameObjectsWithTag("Bullet");
        bullets.AddRange(bulletsArray);
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {


        Vector2 input = moveAction.ReadValue<Vector2>();

        if (input != Vector2.zero)
        {
            transform.Translate(input * Time.deltaTime * 5f);
        }


        if ((InputSystem.actions["Player/Shoot"].WasPressedThisFrame()))
        {

            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                    break;
                }
            }

        }


        if (transform.position.y != -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
        if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }




    }




}
