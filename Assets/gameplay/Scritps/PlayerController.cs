using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Variaveis de controle")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rigiBody;
    private float moveInputHorizontal;
    private Animator animator;
    private bool isRunning = false;
    private bool isJumping = false;

    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");

        Running();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            Jump();
        }

        if (Mathf.Abs(rigiBody.linearVelocityY) > 0.1f)
        {
            isJumping = true;
            animator.SetBool("IsJumping", isJumping);
        }
        else
        {
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
        }


    }

    void FixedUpdate()
    {
        rigiBody.linearVelocity = new Vector2(moveInputHorizontal * moveSpeed, rigiBody.linearVelocityY);
        if (moveInputHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveInputHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void Running() {
        if (moveInputHorizontal != 0)
        {
            isRunning = true;
        }
        else {
            isRunning = false;
        }
        animator.SetBool("isRunning", isRunning);
    }

    void Jump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (hit.collider != null) {
            rigiBody.linearVelocity = new Vector2(rigiBody.linearVelocityX, jumpForce);
            animator.SetBool("IsJumping", true);
        }  

    }
}
