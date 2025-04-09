using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Variaveis de controle")]
    public float moveSpeed = 5f;
    private Rigidbody2D rigiBody;
    private float moveInput;

    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

   void FixedUpdate()
    {
        rigiBody.linearVelocity = new Vector2(moveInput * moveSpeed, rigiBody.linearVelocityY); 
    }
}
