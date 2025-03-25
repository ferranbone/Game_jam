using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    private Rigidbody2D rb;
    public AudioClip audioClip;  // El clip de audio que deseas reproducir
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("perder"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  // Reproducir el audio
                Debug.Log("audio");
            }
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
