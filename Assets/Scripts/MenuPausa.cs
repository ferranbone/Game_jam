using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuConfiguracion;
    private bool estaPausado = false;
    private bool enConfiguracion = false;


    void Start()
    {
        menuPausa.SetActive(false);
        menuConfiguracion.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enConfiguracion)
            {
                MostrarMenuPausa();
            }
            else
            {
                AlternarPausa();
            }
        }
    }

    private void AlternarPausa()
    {
        if (estaPausado)
            Reanudar();
        else
            Pausar();
    }

    public void Pausar()
    {
        CambiarEstadoMenus(true, false);
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void Reanudar()
    {
        CambiarEstadoMenus(false, false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FerranScene");
    }

    public void AbrirConfiguracion()
    {
        CambiarEstadoMenus(false, true);
    }

    public void MostrarMenuPausa()
    {
        CambiarEstadoMenus(true, false);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void CambiarEstadoMenus(bool mostrarPausa, bool mostrarConfiguracion)
    {
        menuPausa.SetActive(mostrarPausa);
        menuConfiguracion.SetActive(mostrarConfiguracion);
        enConfiguracion = mostrarConfiguracion;
    }
}
