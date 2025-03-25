using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float distancia = 1.0f;
    public float speed = 2f; // Velocidad de movimiento
    public GameObject gameOver;
    private Vector3 posicionInicial;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.position = posicionInicial+Vector3.left*Mathf.PingPong(Time.time * speed, distancia);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
