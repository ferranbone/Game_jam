using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ApareceSuelo : MonoBehaviour
{
    private Tilemap tilemap;
    private Color originalColor;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        originalColor = tilemap.color; // Guardamos el color original
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetTilemapAlpha(1f); // Hace el Tilemap totalmente visible
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetTilemapAlpha(originalColor.a); // Restaura el alfa original
        }
    }

    void SetTilemapAlpha(float alpha)
    {
        Color newColor = tilemap.color;
        newColor.a = alpha;
        tilemap.color = newColor;
    }
}