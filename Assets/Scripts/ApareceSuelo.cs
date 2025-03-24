using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ApareceSuelo : MonoBehaviour
{
    public Tilemap tilemap;  // El tilemap donde están los tiles
    public Color colorTransparente = new Color(1f, 1f, 1f, 0f); // Transparente por defecto
    public Color colorVisible = new Color(1f, 1f, 1f, 1f);  // Opaco cuando colisiona con el jugador

    private void Start()
    {
        // Cambiar la transparencia a todos los tiles al inicio
        CambiarTransparencia(colorTransparente);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador entra en contacto, hacemos los tiles visibles
            CambiarTransparencia(colorVisible);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador sale del área de colisión, hacer los tiles transparentes de nuevo
            CambiarTransparencia(colorTransparente);
        }
    }

    // Función para cambiar la transparencia de todos los tiles
    private void CambiarTransparencia(Color nuevoColor)
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        foreach (var tile in allTiles)
        {
            if (tile != null)
            {
                // Cambiar el color de cada tile en el Tilemap
                // Asumimos que el tile tiene un material con transparencia
                Material mat = tilemap.GetComponent<SpriteRenderer>().material;

                if (mat != null)
                {
                    mat.color = nuevoColor;
                }
            }
        }
    }
}