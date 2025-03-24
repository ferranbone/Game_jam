using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador1; // El primer jugador
    public Transform jugador2; // El segundo jugador
    public float offsetY = 0f; // Desplazamiento en Y para mantener la cámara en una altura fija
    public float suavizado = 0.1f; // Suavizado para el movimiento de la cámara (opcional, para hacerlo más suave)

    private Vector3 _velocidad = Vector3.zero; // Velocidad para suavizado

    void Update()
    {
        Vector3 puntoMedio = (jugador1.position + jugador2.position) / 2;

        Vector3 nuevaPosicion = new Vector3(puntoMedio.x, offsetY, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, nuevaPosicion, ref _velocidad, suavizado);


    }
}
