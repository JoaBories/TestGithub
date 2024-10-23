using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private GameObject isOnGroundTrigger;

    private Controls _inputActions;
    private InputAction _moveActions;

    private bool isMoving;
    private bool canJump;


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
        if (canJump && isOnGround())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
            canJump = false;
        }
    }

    void Update()
    {
        if (isOnGround()) canJump = true;

        float moveDir = _moveActions.ReadValue<Vector2>().x;
        if (moveDir < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isMoving = true;
        }
        else if (moveDir == 0) isMoving = false;
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isMoving =true;
        }

        transform.position += new Vector3(moveDir * Speed * Time.deltaTime, 0, 0);
    }

    private bool isOnGround()
    {
        return isOnGroundTrigger.GetComponent<IsOnGroundTrigger>().IsGround;
    }

    IEnumerator timetodestroy(float time, GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(time);
        Destroy(objectToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            GetComponent<Animator>().Play("playerEat");
            StartCoroutine(timetodestroy(0.3f, collision.gameObject));
        }
    }
}
