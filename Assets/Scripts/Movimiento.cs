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
    private Animator animator;
    public AudioClip audioClip;  // El clip de audio que deseas reproducir
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        float moveInput = Input.GetAxisRaw("Horizontal"); // Obtener entrada de teclado (A/D o flechas)

        // Movimiento del personaje en el eje horizontal
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (isGrounded && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("mover", true);
        }
        else if (isGrounded && Input.GetKey(KeyCode.A)){
            animator.SetBool("mover2", true);
        }
        else
        {
            animator.SetBool("mover", false);
            animator.SetBool("mover2", false);
        }

    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar la fuerza del salto
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
        if (collision.gameObject.CompareTag("suelo") || collision.gameObject.CompareTag("invisible"))
        {
            isGrounded = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo") || collision.gameObject.CompareTag("invisible"))
        {
            isGrounded = false;
        }
    }
}
