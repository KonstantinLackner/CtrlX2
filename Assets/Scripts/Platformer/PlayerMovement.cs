using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private static readonly int Burning = Animator.StringToHash("Burning");
    private bool burning = false;

    private bool canMove = true;
    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            burning = true;
            myAnim.SetTrigger(Burning);

            StartCoroutine(playerDies());
        }
    }

    private IEnumerator playerDies()
    {
        canMove = false;
        yield return new WaitForSeconds(2);
        sceneLoader.LoadInputLevel();
    }

    public void killPlayer()
    {
        StartCoroutine(playerVoidKill());
    }

    private IEnumerator playerVoidKill()
    {
        Destroy(GetComponent<SpriteRenderer>());
        canMove = false;
        yield return new WaitForSeconds(5);
        
        if (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Level3")))
        {
            sceneLoader.LoadInputLevel();
        }
    }
}