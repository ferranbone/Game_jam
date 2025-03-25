using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento
    private int direction = -1; // -1: izquierda, 1: derecha

    void Update()
    {
        // Mueve al enemigo en la dirección establecida
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha perdido");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con un obstáculo, cambia de dirección
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}
