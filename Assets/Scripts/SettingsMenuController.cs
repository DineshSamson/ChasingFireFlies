using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject obj;

    private float volume;
    public Slider volumeSlider;

    private int selectedGrid;
    public GridButtons[] gridButtons;

    public void OpenSettingsMenu()
    {
        SetupScreen();
    }

    public void SetupVolume()
    {      
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void SelectedGridButton(int index)
    {
        for(int i = 0; i < gridButtons.Length; i++) 
        {
            gridButtons[i].gridImage.color = Color.white;
        }
        PlayerPrefs.SetInt("SelectedGrid", index);

        gridButtons[index].gridImage.color = Color.green;
    }

    public void SetupScreen()
    {

        if(PlayerPrefs.HasKey("Volume") && PlayerPrefs.HasKey("SelectedGrid"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");


            SelectedGridButton(PlayerPrefs.GetInt("SelectedGrid"));
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");

            PlayerPrefs.SetInt("SelectedGrid", 0);
            SelectedGridButton(PlayerPrefs.GetInt("SelectedGrid"));
        }

        obj.SetActive(true);
    }

    public void CloseSettingsScreen()
    {
        obj.SetActive(false);
    }
}
