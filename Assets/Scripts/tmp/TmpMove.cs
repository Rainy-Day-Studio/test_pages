using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TmpMove : MonoBehaviour
{
    public float speed = 5f;
    private InputSystem_Actions _inputSystemActions;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        _inputSystemActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputSystemActions.Enable();
    }

    private void OnDisable()
    {
        _inputSystemActions.Disable();
    }

    private void Start()
    {
        _inputSystemActions.Player.Move.performed += OnMove;
        _inputSystemActions.Player.Move.canceled += OnMoveStopped;
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        //Debug.Log($"Move Input: {moveInput}");
    }
    
    void OnMoveStopped(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveInput * (speed * Time.fixedDeltaTime));
        //Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);
        //transform.position += movement * (speed * Time.fixedDeltaTime);
    }
}
