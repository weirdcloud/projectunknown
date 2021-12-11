using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    PowerUps activePowerUps;

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

    public UnityEvent DoubleJump;
    public UnityEvent Jump;

    bool isGrounded = false;
    bool isTouchingCeiling = false;

    float horizontal;
    float currentVerticalSpeed = 0f;
    int currentDoubleJumpCount;
    Animator animator;

    public int MaxDoubleJumpCount 
    { 
        get
        {
            if (activePowerUps.tripleJump)
                return 2;
            else return maxDoubleJumpCount;
        }
        set => maxDoubleJumpCount = value; 
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentDoubleJumpCount = MaxDoubleJumpCount;

        ceilCheck.changeCeiling.AddListener(OnChangeCeiling);
        groundCheck.changeGrounded.AddListener(OnChangeGrounded);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        SetAnimatorVariables();

        if (IsGrounded())
        {
            currentDoubleJumpCount = MaxDoubleJumpCount;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                currentVerticalSpeed = Mathf.Sqrt(-2 * -gravity * jumpHeight);
                Jump.Invoke();
            }
            else if (currentDoubleJumpCount > 0)
            {
                currentVerticalSpeed = Mathf.Sqrt(-2 * -gravity * jumpHeight);
                currentDoubleJumpCount--;
                DoubleJump.Invoke();
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

    public void OnChangeGrounded(bool value)
    {
        isGrounded = value;
    }

    public void OnChangeCeiling(bool value)
    {
        isTouchingCeiling = value;
    }

    bool IsGrounded()
    {
        return isGrounded;
    }

    bool IsTouchingCeiling()
    {
        return isTouchingCeiling;
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
