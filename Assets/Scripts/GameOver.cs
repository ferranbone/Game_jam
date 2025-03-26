using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    private Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("perder"))
        {
            
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
