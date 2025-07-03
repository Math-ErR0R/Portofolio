using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManagerMain : MonoBehaviour
{

    public GameObject MainMenuScreen;
    public AudioMixer audioMixer;
   
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Explaination");
    }

    public void SetRes(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVol(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

   public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull; 
        Screen.fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed; 
    }

    public void quit()
    {
        Application.Quit();
    }
    
}