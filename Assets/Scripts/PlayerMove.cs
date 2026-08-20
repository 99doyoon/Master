using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody2D;
    public bool CanMove { get; set; } = true;

    private Vector2 moveInput;

    private void FixedUpdate()
    {
        if (!CanMove)
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }

        rigidbody2D.linearVelocity = moveInput * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void SetMoveState(bool inventoryOpen)
    {
        CanMove = !inventoryOpen;

        if (!CanMove)
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    private void OnEnable()
    {
        ShopManager.OnShopStateChanged += SetMoveState;
    }

    private void OnDisable()
    {
        ShopManager.OnShopStateChanged -= SetMoveState;
    }
}
