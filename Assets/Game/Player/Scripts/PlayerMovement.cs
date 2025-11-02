using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;
    private PlayerInputActions playerInput;

    public bool isPlayerDead = false;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += JumpAction;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Even though it is fixed update Time.deltaTime should be taken into account. So in your game please show me how you used this time delta time
    private void FixedUpdate()
    {
        if (!isPlayerDead)
        {
            float axis = playerInput.Player.HorizontalMovement.ReadValue<float>();

            rb.linearVelocity = new Vector2(axis * movementSpeed * Time.deltaTime, rb.linearVelocity.y);

            //rb.linearVelocityX = axis * movementSpeed; // Another way to read input value for one axis like X
        } else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void JumpAction(InputAction.CallbackContext context)
    {
        if (IsGrounded() && !isPlayerDead)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Vector2.up is the same as new Vector2(0f, 1f)
        }
    }
}
