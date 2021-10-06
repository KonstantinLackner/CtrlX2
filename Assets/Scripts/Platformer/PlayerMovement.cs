using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private Animator myAnim;
    [SerializeField] private SpriteRenderer mySpriteRenderer;

    private bool isGrounded = false;
    [SerializeField] private Transform isGroundChecker;
    [SerializeField] private float checkGroundRadius;

    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfGrounded();
        Jump();
        JumpEnhancement();
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float moveBy = horizontalAxis * speed;

        playerRigidbody.velocity = new Vector2(moveBy, playerRigidbody.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }

    void JumpEnhancement()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}