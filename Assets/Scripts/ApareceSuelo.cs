using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceSuelo : MonoBehaviour
{
    private Renderer objectRenderer; // El Renderer del objeto
    private Color objectColor; // El color del material
    public float fadeSpeed = 0.5f; // Velocidad de cambio de alfa
    private bool isColliding = false; // Si está en colisión con el objeto "Invisible"

    void Start()
    {
        // Obtén el Renderer del objeto
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            // Obtén el color actual del material
            objectColor = objectRenderer.material.color;
        }
    }

    void Update()
    {
        // Si estamos colisionando con un objeto "Invisible", incrementa la opacidad
        if (isColliding && objectColor.a < 1f)
        {
            // Aumentar el valor alfa del color
            objectColor.a += fadeSpeed * Time.deltaTime;
            // Actualiza el color del material
            objectRenderer.material.color = objectColor;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si colisionamos con un objeto con el tag "Invisible", comienza el fade in
        if (collision.gameObject.CompareTag("player"))
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isColliding = false;
        }
    }
}
