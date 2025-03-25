using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuConfiguracion;

    // Start is called before the first frame update
    void Start()
    {
        menuConfiguracion.SetActive(false);
    }
    public void NuevaPartida()
    {
        SceneManager.LoadScene("FerranScene");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Config()
    {
        menuConfiguracion.SetActive(true);
    }
    public void CerrarConfiguracion()
    {
        menuConfiguracion.SetActive(false);
    }
}
