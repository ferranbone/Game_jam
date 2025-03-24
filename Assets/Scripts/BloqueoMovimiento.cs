using UnityEngine;

public class BloqueoMovimiento : MonoBehaviour
{
    public Transform jugador1; // El primer jugador
    public Transform jugador2; // El segundo jugador
    public float distanciaMaxima = 10f; // Distancia máxima entre los jugadores
    public float velocidadMovimiento = 5f; // Velocidad de movimiento de los jugadores (si usas este valor)

    void Update()
    {
        Bloqueo();    
    }

    void Bloqueo()
    {
        // Verificar la distancia entre los dos jugadores
        float distancia = Mathf.Abs(jugador1.position.x - jugador2.position.x);

        // Si la distancia entre los dos jugadores es mayor que la distancia máxima, restringir su movimiento
        if (distancia > distanciaMaxima)
        {
            // Ajustar las posiciones de los jugadores para que no se separen más allá de la distancia máxima
            if (jugador1.position.x < jugador2.position.x)
            {
                jugador2.position = new Vector3(jugador1.position.x + distanciaMaxima, jugador2.position.y, jugador2.position.z);
            }
            else
            {
                jugador1.position = new Vector3(jugador2.position.x + distanciaMaxima, jugador1.position.y, jugador1.position.z);
            }
        }
    }
}
