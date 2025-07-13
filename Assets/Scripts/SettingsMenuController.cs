using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject obj;

    private float volume;
    public Slider volumeSlider;

    private int selectedGrid;
    public GridButtons[] gridButtons;

    public Color gridSelectedColor;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedGrid"))
            SelectedLayout(0);
        else
        {
            SelectedLayout(PlayerPrefs.GetInt("SelectedGrid"));
        }

    }

    public void OpenSettingsMenu()
    {
        SetupScreen();
    }

    public void SetupVolume()
    {      
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        SoundManager.instance.AdjustVolume(volumeSlider.value);
    }

    public void SelectedGridButton(int index)
    {
        for(int i = 0; i < gridButtons.Length; i++) 
        {
            gridButtons[i].gridImage.color = Color.white;
        }
        PlayerPrefs.SetInt("SelectedGrid", index);

        gridButtons[index].gridImage.color = gridSelectedColor;

        SelectedLayout(index);
    }

    public void SelectedLayout(int Index)
    {
        //PlayerPrefs.SetInt("Layout", Index);
        if (Index == 0)
        {
            Singleton.instance.gameController.rowCount = 2;
            Singleton.instance.gameController.columnCount = 2;
        }
        else if (Index == 1)
        {
            Singleton.instance.gameController.rowCount = 2;
            Singleton.instance.gameController.columnCount = 3;
        }
        else if (Index == 2)
        {
            Singleton.instance.gameController.rowCount = 5;
            Singleton.instance.gameController.columnCount = 6;
        }
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
