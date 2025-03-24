using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 7f;
    public Transform groundCheck; // Referencia al punto de chequeo de suelo
    public LayerMask groundLayer;

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Obtener entrada de teclado (A/D o flechas)

        // Movimiento del personaje en el eje horizontal
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        
        // Si está en el suelo y presionamos la tecla de salto (espacio)
        if (/*isGrounded && */Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar la fuerza del salto
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si colisionamos con un objeto con el tag "Invisible", comienza el fade in
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
        }
    }
}
