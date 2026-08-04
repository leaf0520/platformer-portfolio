using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

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
}