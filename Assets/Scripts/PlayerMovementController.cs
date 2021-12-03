using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private GroundCheck groundCheck;
    [SerializeField]
    private CeilingCheck ceilCheck;

    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private float maxVerticalSpeed = 6f;
    [SerializeField]
    private float gravity = 1;
    [SerializeField]
    private float jumpDownScale = 1;
    [SerializeField]
    private float jumpHeight = 2;

    [SerializeField]
    private int maxDoubleJumpCount = 1;

    float horizontal;
    float currentVerticalSpeed = 0f;
    int currentDoubleJumpCount;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentDoubleJumpCount = maxDoubleJumpCount;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        SetAnimatorVariables();

        if (IsGrounded())
        {
            currentDoubleJumpCount = maxDoubleJumpCount;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                currentVerticalSpeed = Mathf.Sqrt(-2 * -gravity * jumpHeight);
            }
            else if (currentDoubleJumpCount > 0)
            {
                currentVerticalSpeed = Mathf.Sqrt(-2 * -gravity * jumpHeight);
                currentDoubleJumpCount--;
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalPos = horizontal * Time.fixedDeltaTime * moveSpeed;

        float verticalPos;
        currentVerticalSpeed -= gravity * Time.fixedDeltaTime;

        if (currentVerticalSpeed < - maxVerticalSpeed)
            currentVerticalSpeed = - maxVerticalSpeed;

        if (currentVerticalSpeed < 0)
        {
            if (IsGrounded())
                currentVerticalSpeed = 0f;
            verticalPos = jumpDownScale * currentVerticalSpeed * Time.fixedDeltaTime;
        }
        else
        {
            if (IsTouchingCeiling())
                currentVerticalSpeed = 0f;
            verticalPos = currentVerticalSpeed * Time.fixedDeltaTime;
        }
        
        rb2d.MovePosition(rb2d.position + new Vector2(horizontalPos, verticalPos));
    }

    bool IsGrounded()
    {
        return groundCheck.GetIsGrounded();
    }

    bool IsTouchingCeiling()
    {
        return ceilCheck.GetIsTouchingCeiling();
    }

    void SetAnimatorVariables()
    {
        animator.SetInteger("horizontal", (int)horizontal);
        animator.SetBool("isGrounded", IsGrounded());
        if (!IsGrounded())
        {
            if (currentVerticalSpeed > 0)
                animator.SetInteger("vertical", 1);
            else if (currentVerticalSpeed < 0)
                animator.SetInteger("vertical", -1);
        }
        else
            animator.SetInteger("vertical", 0);
    }
}
