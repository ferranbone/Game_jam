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
    private Animator animator;
    public AudioClip audioClip;  // El clip de audio que deseas reproducir
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -1;
        audioSource = GetComponent<AudioSource>();
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
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
        if (isGrounded && Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("derecha", true);
        }
        else if (isGrounded && Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("izquierda", true);
        }
        else
        {
            animator.SetBool("derecha", false);
            animator.SetBool("izquierda", false);
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump1"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce); // Aplicar la fuerza del salto
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  // Reproducir el audio
                Debug.Log("audio");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisionamos con un objeto con el tag "Invisible", comienza el fade in
        if (collision.gameObject.CompareTag("techo") || collision.gameObject.CompareTag("invisible"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("techo") || collision.gameObject.CompareTag("invisible"))
        {
            isGrounded = false;
        }
    }
}
