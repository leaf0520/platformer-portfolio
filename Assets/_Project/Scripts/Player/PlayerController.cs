using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        if (moveInput.x > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0f)
        {
            spriteRenderer.flipX = true;
        }

        bool isMoving = moveInput.sqrMagnitude > 0f;
        animator.SetBool("IsMoving", isMoving);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }
}