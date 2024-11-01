using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 2f;          
    public float rotationSpeed = 360f; 

    private PlayerControls controls;   
    private Vector2 moveInput;         
    private Animator anim;             

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotate the player to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Update the animator's IsMoving parameter
        bool isMoving = moveInput != Vector2.zero;
        anim.SetBool("IsMoving", isMoving);
    }
}
