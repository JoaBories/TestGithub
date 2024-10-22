using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float jumpSpeed;

    private Controls _inputActions;
    private InputAction _moveActions;


    private void Awake()
    {
        _inputActions = new Controls();
    }

    private void OnEnable()
    {
        _inputActions.Gameplay.Jump.performed += jump;
        _inputActions.Gameplay.Jump.Enable();

        _moveActions = _inputActions.Gameplay.Move;
        _moveActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Gameplay.Jump.performed -= jump;
        _inputActions.Gameplay.Jump.Disable();

        _moveActions.Enable();
    }

    private void jump(InputAction.CallbackContext context)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }


    void Update()
    {
        float moveDir = _moveActions.ReadValue<Vector2>().x;
        transform.position += new Vector3(moveDir * Speed * Time.deltaTime, 0, 0);
    }
}
