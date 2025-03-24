using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTecho : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 7f; // Fuerza salto
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal1"); 

        // Movimiento del personaje en el eje horizontal
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump1"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce); // Aplicar la fuerza del salto
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisionamos con un objeto con el tag "Invisible", comienza el fade in
        if (collision.gameObject.CompareTag("techo"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("techo"))
        {
            isGrounded = false;
        }
    }
}
