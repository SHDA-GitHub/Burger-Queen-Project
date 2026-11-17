using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    private ThirdPersonMovement PlayerActions;
    private InputAction move;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float MovementSpeed;
    private Vector3 Movement;


    void Start()
    {
        PlayerActions = new ThirdPersonMovement();
        PlayerActions.Player.Enable();
        PlayerActions.Player.Move.performed += OnMovement;
        PlayerActions.Player.Move.canceled += StopMovement;
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        Movement = Vector3.zero;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(Movement.x * -MovementSpeed, rb.linearVelocity.y , Movement.z * -MovementSpeed);

        Debug.Log(rb.linearVelocity);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
        Movement.x = context.ReadValue<Vector2>().x;
        Movement.z = context.ReadValue<Vector2>().y;
    }


}
