using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConfiguracion : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown fullscreenDropdown;

    private List<Resolution> resolutions;
    private readonly List<string> resolutionOptions = new List<string>()
    {
        "1920 x 1080",
        "1280 x 720",
        "1600 x 900"
    };

    private readonly List<string> screenModeOptions = new List<string>()
    {
        "Pantalla Completa",
        "Ventana",
        "Ventana Sin Bordes"
    };

    // Start is called before the first frame update
    void Start()
    {
        resolutions = new List<Resolution>();

        // Agregar resoluciones predefinidas a la lista
        resolutions.Add(new Resolution { width = 1920, height = 1080 });
        resolutions.Add(new Resolution { width = 1280, height = 720 });
        resolutions.Add(new Resolution { width = 1600, height = 900 });

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        // Llenar el dropdown con las resoluciones predefinidas
        for (int i = 0; i < resolutionOptions.Count; i++)
        {
            options.Add(resolutionOptions[i]);
            if (Screen.width == resolutions[i].width && Screen.height == resolutions[i].height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        fullscreenDropdown.AddOptions(screenModeOptions);
        fullscreenDropdown.value = PlayerPrefs.GetInt("screenMode", 0);  // 0: Pantalla Completa, 1: Ventana, 2: Ventana Sin Bordes
        fullscreenDropdown.RefreshShownValue();

        ApplySettings();
    }

    public void SetScreenMode(int index)
    {
        PlayerPrefs.SetInt("screenMode", index);
        ApplySettings();
    }

    public void SetResolution(int index)
    {
        PlayerPrefs.SetInt("resolution", index);
        ApplySettings();
    }

    private void ApplySettings()
    {
        int resolutionIndex = PlayerPrefs.GetInt("resolution", 0);
        int screenModeIndex = PlayerPrefs.GetInt("screenMode", 0);

        bool isFullscreen = false;

        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, resolution.refreshRateRatio);

        switch (screenModeIndex)
        {
            case 0: // Pantalla Completa
                isFullscreen = true;
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);
                break;
            case 1: // Ventana
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
                break;
            case 2: // Ventana Sin Bordes
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.MaximizedWindow);
                break;
        }
    }
}
